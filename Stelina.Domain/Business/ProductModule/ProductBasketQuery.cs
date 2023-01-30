using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Stelina.Domain.AppCode.Extensions;
using Stelina.Domain.Models.DataContexts;
using Stelina.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Stelina.Domain.Business.ProductModule
{
    public class ProductBasketQuery : IRequest<List<Basket>>
    {
        public class ProductBasketQueryHandler : IRequestHandler<ProductBasketQuery, List<Basket>>
        {
            private readonly StelinaDbContext db;
            private readonly IActionContextAccessor ctx;

            public ProductBasketQueryHandler(StelinaDbContext db, IActionContextAccessor ctx)
            {
                this.db = db;
                this.ctx = ctx;
            }
            public async Task<List<Basket>> Handle(ProductBasketQuery request, CancellationToken cancellationToken)
            {
                var userId = ctx.GetCurrentUserId();

                var data = await db.Basket
                    .Include(b => b.Product)
                    .ThenInclude(p => p.Images.Where(i => i.IsMain == true && i.DeletedDate == null))
                    .Where(b => b.UserId == userId)
                    .ToListAsync(cancellationToken);

                return data;
            }
        }
    }
}
