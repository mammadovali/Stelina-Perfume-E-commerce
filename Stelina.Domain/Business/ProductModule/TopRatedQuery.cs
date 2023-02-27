using MediatR;
using Microsoft.EntityFrameworkCore;
using Stelina.Domain.Models.DataContexts;
using Stelina.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Stelina.Domain.Business.ProductModule
{
    public class TopRatedQuery : IRequest<IEnumerable<Product>>
    {
        public class TopRatedQueryHandler : IRequestHandler<TopRatedQuery, IEnumerable<Product>>
        {
            private readonly StelinaDbContext db;

            public TopRatedQueryHandler(StelinaDbContext db)
            {
                this.db = db;
            }
            public async Task<IEnumerable<Product>> Handle(TopRatedQuery request, CancellationToken cancellationToken)
            {
                var data = await db.Products
                    .Include(p => p.Images.Where(pi => pi.IsMain == true))
                    .Where(p => p.Rate > 3 && p.DeletedDate == null)
                    .Take(8)
                    .OrderByDescending(p => p.Rate)
                    .ToListAsync(cancellationToken);

                return data;
            }
        }
    }
}
