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
    public class AddToBasketCommand : IRequest<JsonResponse>
    {
        public int ProductId { get; set; }

        public class AddToBasketCommandHandler : IRequestHandler<AddToBasketCommand, JsonResponse>
        {
            private readonly StelinaDbContext db;
            private readonly IActionContextAccessor ctx;

            public AddToBasketCommandHandler(StelinaDbContext db, IActionContextAccessor ctx)
            {
                this.db = db;
                this.ctx = ctx;
            }

            public async Task<JsonResponse> Handle(AddToBasketCommand request, CancellationToken cancellationToken)
            {
                var userId = ctx.GetCurrentUserId();

                //if (userId == 0)
                //{
                //    return new JsonResponse
                //    {
                //        Error = true,
                //        Message = "You should log in to your account first"
                //    };
                //}

                var alreadyExits = await db.Basket.AnyAsync(b => b.ProductId == request.ProductId && b.UserId == userId, cancellationToken);


                if (alreadyExits)
                {
                    return new JsonResponse
                    {
                        Error = false,
                        Message = "Product already exist in your basket"
                    };
                }

                var basketItem = new Basket
                {
                    UserId = userId,
                    ProductId = request.ProductId,
                    Quantity = 1
                };

                await db.Basket.AddAsync(basketItem, cancellationToken);
                await db.SaveChangesAsync(cancellationToken);

                //#region Baskete elave olunandan sonra wishlistden silinme
                //var value = ctx.GetIntArrayFromCookie("favorites");

                //if (value != null)
                //{
                //    var newFavIds = value.Where(fi => fi != request.ProductId);
                //    var cookieValue = string.Join(",", newFavIds);

                //    var cookie = new KeyValuePair<string, string>("favorites", cookieValue);

                //    ctx.ActionContext.HttpContext.Request.Cookies.Append(cookie);

                //    ctx.SetValueToCookie("favorites", cookieValue);
                //}

                //#endregion

                return new JsonResponse
                {
                    Error = false,
                    Message = "Product was added to the basket"
                };
            }


        }
    }
}
