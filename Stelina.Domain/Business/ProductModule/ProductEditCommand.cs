using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Stelina.Domain.AppCode.Extensions;
using Stelina.Domain.Models.DataContexts;
using Stelina.Domain.Models.Entities;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Stelina.Domain.Business.ProductModule
{
    public class ProductEditCommand : IRequest<Product>
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string StockKeepingUnit { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string Description { get; set; }

        public int BrandId { get; set; }

        public int CategoryId { get; set; }

        [Required]
        public ImageItem[] Images { get; set; }


        public class ProductEditCommandHandler : IRequestHandler<ProductEditCommand, Product>
        {
            private readonly StelinaDbContext db;
            private readonly IHostEnvironment env;
            private readonly IActionContextAccessor ctx;

            public ProductEditCommandHandler(StelinaDbContext db, IHostEnvironment env, IActionContextAccessor ctx)
            {
                this.db = db;
                this.env = env;
                this.ctx = ctx;
            }

            public async Task<Product> Handle(ProductEditCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var model = await db.Products
                     .Include(p => p.Images.Where(i => i.DeletedDate == null))   
                     .FirstOrDefaultAsync(p => p.Id == request.Id && p.DeletedDate == null, cancellationToken);

                    if (model == null)
                    {
                        return null;
                    }

                    model.Name = request.Name;
                    model.StockKeepingUnit = request.StockKeepingUnit;
                    model.Price = request.Price;
                    model.Description = request.Description;
                    model.BrandId = request.BrandId;
                    model.CategoryId = request.CategoryId;

                    /*
                    1. sekil deyisdirmek istemirse
                    2. elave sekil artirsa + 
                    3 var olan sekli silibse
                     */

                    if (request.Images != null && request.Images.Count() > 0)
                    {
                        #region 2.Teze fayllar var
                        foreach (var imageItem in request.Images.Where(i => i.File != null && i.Id == null))
                        {

                            var image = new ProductImage();
                            image.IsMain = imageItem.IsMain;
                            image.ProductId = model.Id;

                            string extension = Path.GetExtension(imageItem.File.FileName);//.jpg

                            image.Name = $"product-{Guid.NewGuid().ToString().ToLower()}{extension}";

                            string fullName = env.GetImagePhysicalPath(image.Name);

                            using (var fs = new FileStream(fullName, FileMode.Create, FileAccess.Write))
                            {
                                await imageItem.File.CopyToAsync(fs, cancellationToken);
                            }

                            model.Images.Add(image);
                        }
                        #endregion

                        #region 3.Movcud sekillerden silinibse
                        foreach (var item in request.Images.Where(i => i.Id > 0 && i.TempPath == null))
                        {
                            var productImage = await db.ProductImages.FirstOrDefaultAsync(pi => pi.Id == item.Id && pi.ProductId == model.Id && pi.DeletedDate == null);

                            if (productImage != null)
                            {
                                productImage.IsMain = false;
                                productImage.DeletedDate = DateTime.UtcNow.AddHours(4);
                            }
                        }
                        #endregion


                        #region 1.Movcud deyishdirmek istemese

                        foreach (var item in model.Images)
                        {
                            var fromForm = request.Images.FirstOrDefault(i => i.Id == item.Id);

                            if (fromForm != null)
                            {
                                item.IsMain = fromForm.IsMain;
                            }

                          
                        }
                        #endregion
                    }

                    await db.SaveChangesAsync(cancellationToken);


                    return model;

                }
                catch (System.Exception)
                {
                    return null;
                }

            }
        }
    }
}
