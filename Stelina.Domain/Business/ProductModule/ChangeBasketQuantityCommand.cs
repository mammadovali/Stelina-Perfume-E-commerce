using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Stelina.Domain.AppCode.Extensions;
using Stelina.Domain.AppCode.Infrastructure;
using Stelina.Domain.Models.DataContexts;
using Stelina.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Stelina.Domain.Business.BasketModule
{
    public class ChangeBasketQuantityCommand : IRequest<JsonResponse>
    {
        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public class ChangeBasketQuantityCommandHandler : IRequestHandler<ChangeBasketQuantityCommand, JsonResponse>
        {
            private readonly StelinaDbContext db;
            private readonly IActionContextAccessor ctx;

            public ChangeBasketQuantityCommandHandler(StelinaDbContext db, IActionContextAccessor ctx)
            {
                this.db = db;
                this.ctx = ctx;
            }

            public async Task<JsonResponse> Handle(ChangeBasketQuantityCommand request, CancellationToken cancellationToken)
            {
                var userId = ctx.GetCurrentUserId();

                var basketItem = await db.Basket.FirstOrDefaultAsync(b => b.ProductId == request.ProductId && b.UserId == userId, cancellationToken);

                if (basketItem == null)
                {
                    basketItem = new Basket
                    {
                        UserId = userId,
                        ProductId = request.ProductId,
                        Quantity = request.Quantity < 1 ? 1 : request.Quantity
                    };

                    await db.Basket.AddAsync(basketItem, cancellationToken);
                    await db.SaveChangesAsync();

                    var response = new JsonResponse
                    {
                        Error = false,
                        Message = "Product was added to the basket"
                    };

                    var product = await db.Products.FirstOrDefaultAsync(b => b.Id == request.ProductId
                                            && b.DeletedDate == null, cancellationToken);

                  
                    response.Value = new
                    {
                        Total = (basketItem.Quantity * product.Price).ToString("0.00"),
                        Summary = await db.Basket.Where(b => b.UserId == userId).Include(b => b.Product).SumAsync(b => b.Quantity * b.Product.Price, cancellationToken),
                        Quantity = (await db.Basket.FirstOrDefaultAsync(b => b.UserId == userId && b.ProductId == product.Id)).Quantity
                    };

                    return response;
                }

                basketItem.Quantity = request.Quantity;

                await db.SaveChangesAsync(cancellationToken);

                var response2 = new JsonResponse
                {
                    Error = false,
                    Message = "Quantity of the product was changed"
                };

                var product2 = await db.Products.FirstOrDefaultAsync(b => b.Id == request.ProductId
                                       && b.DeletedDate == null, cancellationToken);


                response2.Value = new
                {
                    Total = (basketItem.Quantity * product2.Price).ToString("0.00"),
                    Summary = await db.Basket.Where(b => b.UserId == userId).Include(b => b.Product).SumAsync(b => b.Quantity * b.Product.Price, cancellationToken),
                    Quantity = (db.Basket.FirstOrDefault(b => b.UserId == userId && b.ProductId == product2.Id)).Quantity
                };

                return response2;
            }


        }
    }
}
