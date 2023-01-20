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
    public class CategoryGetSingleQuery : IRequest<Category>
    {
        public int Id { get; set; }

        public class CategoryGetSingleQueryHandler : IRequestHandler<CategoryGetSingleQuery, Category>
        {
            private readonly StelinaDbContext db;

            public CategoryGetSingleQueryHandler(StelinaDbContext db)
            {
                this.db = db;
            }

            public async Task<Category> Handle(CategoryGetSingleQuery request, CancellationToken cancellationToken)
            {
                var data = await db.Categories
                    .Include(c => c.Parent)
                    .FirstOrDefaultAsync(p => p.Id == request.Id);

                return data;
            }
        }

    }
}
