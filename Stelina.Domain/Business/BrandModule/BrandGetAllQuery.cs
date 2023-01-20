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
    public class BrandGetAllQuery : IRequest<List<Brand>>
    {
        public class BrandGetAllQueryHandler : IRequestHandler<BrandGetAllQuery, List<Brand>>
        {
            private readonly StelinaDbContext db;

            public BrandGetAllQueryHandler(StelinaDbContext db)
            {
                this.db = db;
            }
            public async Task<List<Brand>> Handle(BrandGetAllQuery request, CancellationToken cancellationToken)
            {
                var entity = await db.Brands
                .Where(bp => bp.DeletedDate == null)
                .ToListAsync(cancellationToken);

                return entity;
            }
        }


    }
}
