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

namespace Stelina.Domain.Business.CategoryModule
{
    public class CategoryGetAllQuery : IRequest<List<Category>>
    {
        public class CategoryGetAllQueryHandler : IRequestHandler<CategoryGetAllQuery, List<Category>>
        {
            private readonly StelinaDbContext db;

            public CategoryGetAllQueryHandler(StelinaDbContext db)
            {
                this.db = db;
            }
            public async Task<List<Category>> Handle(CategoryGetAllQuery request, CancellationToken cancellationToken)
            {
                var data = await db.Categories
                .Where(bp => bp.DeletedDate == null)
                .ToListAsync(cancellationToken);

                return data;
            }
        }


    }
}
