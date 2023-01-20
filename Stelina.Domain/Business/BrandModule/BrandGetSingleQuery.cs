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

namespace Stelina.Domain.Business.BrandModule
{
    public class BrandGetSingleQuery : IRequest<Brand>
    {
        public int Id { get; set; }

        public class BrandGetSingleQueryHandler : IRequestHandler<BrandGetSingleQuery, Brand>
        {
            private readonly StelinaDbContext db;

            public BrandGetSingleQueryHandler(StelinaDbContext db)
            {
                this.db = db;
            }

            public async Task<Brand> Handle(BrandGetSingleQuery request, CancellationToken cancellationToken)
            {
                var data = await db.Brands
                    .FirstOrDefaultAsync(p => p.Id == request.Id);

                return data;
            }
        }

    }
}
