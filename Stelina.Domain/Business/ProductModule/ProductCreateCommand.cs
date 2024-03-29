﻿using MediatR;
using Microsoft.Extensions.Hosting;
using Stelina.Domain.AppCode.Extensions;
using Stelina.Domain.Models.DataContexts;
using Stelina.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Stelina.Domain.Business.ProductModule
{
    public class ProductCreateCommand : IRequest<Product>
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string StockKeepingUnit { get; set; }

        public decimal Price { get; set; }

        [Required]
        public string Description { get; set; }

        public int BrandId { get; set; }

        public int CategoryId { get; set; }

        [Required]
        public ImageItem[] Images { get; set; }


        public class ProductCreateCommandHandler : IRequestHandler<ProductCreateCommand, Product>
        {
            private readonly StelinaDbContext db;
            private readonly IHostEnvironment env;

            public ProductCreateCommandHandler(StelinaDbContext db, IHostEnvironment env)
            {
                this.db = db;
                this.env = env;
            }

            public async Task<Product> Handle(ProductCreateCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var model = new Product();
                    model.Name = request.Name;
                    model.StockKeepingUnit = request.StockKeepingUnit;
                    model.Price = request.Price;
                    model.Description = request.Description;
                    model.BrandId = request.BrandId;
                    model.CategoryId = request.CategoryId;

                    if (request.Images != null && request.Images.Where(i => i.File != null).Count() > 0)
                    {
                        model.Images = new List<ProductImage>();


                        foreach (var item in request.Images.Where(i => i.File != null))
                        {
                            var image = new ProductImage();
                            image.IsMain = item.IsMain;

                            string extension = Path.GetExtension(item.File.FileName);//.jpg

                            image.Name = $"product-{Guid.NewGuid().ToString().ToLower()}{extension}";

                            string fullName = env.GetImagePhysicalPath(image.Name);

                            using (var fs = new FileStream(fullName, FileMode.Create, FileAccess.Write))
                            {
                                await item.File.CopyToAsync(fs, cancellationToken);
                            }

                            model.Images.Add(image);
                        }
                    }

                   
                    await db.Products.AddAsync(model, cancellationToken);
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
