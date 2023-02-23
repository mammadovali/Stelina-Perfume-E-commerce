using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Stelina.Domain.AppCode.Extensions;
using Stelina.Domain.AppCode.Infrastructure;
using Stelina.Domain.Models.DataContexts;
using Stelina.Domain.Models.Entities;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Stelina.Domain.Business.ProductModule
{
    public class SetRateCommand : IRequest<JsonResponse>
    {
        public int ProductId { get; set; }

        public byte Rate { get; set; }

        public class SetRateCommandHandler : IRequestHandler<SetRateCommand, JsonResponse>
        {
            private readonly StelinaDbContext db;
            private readonly IActionContextAccessor ctx;

            public SetRateCommandHandler(StelinaDbContext db, IActionContextAccessor ctx)
            {
                this.db = db;
                this.ctx = ctx;
            }

            public async Task<JsonResponse> Handle(SetRateCommand request, CancellationToken cancellationToken)
            {
                var userId = ctx.GetCurrentUserId();

                var rateEntry = await db.ProductRates.FirstOrDefaultAsync(m => m.ProductId == request.ProductId
                && m.CreatedByUserId == userId, cancellationToken);

                if (rateEntry != null)
                {
                    rateEntry.Rate = request.Rate;
                    rateEntry.CreatedDate = DateTime.Now;
                    await db.SaveChangesAsync(cancellationToken);
                }
                else
                {
                    rateEntry = new ProductRate
                    {
                        ProductId = request.ProductId,
                        Rate = request.Rate,
                        CreatedByUserId = userId,
                        CreatedDate = DateTime.Now
                    };
                    await db.ProductRates.AddAsync(rateEntry, cancellationToken);
                    await db.SaveChangesAsync(cancellationToken);
                }

                var avgRate = db.ProductRates.Where(m => m.ProductId == request.ProductId).Average(m => m.Rate);

                var product = await db.Products.FirstOrDefaultAsync(m => m.Id == request.ProductId, cancellationToken);

                product.Rate = avgRate;
                await db.SaveChangesAsync(cancellationToken);

                return new JsonResponse
                {
                    Error = false,
                    Message = "okay",
                    Value = avgRate
                };
            }
        }
    }
}
