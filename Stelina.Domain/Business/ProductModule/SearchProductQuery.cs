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
    
        public class SearchProductQuery : IRequest<IEnumerable<Product>>
        {
            public string SearchTerm { get; set; }

            public class SearchProductQueryHandler : IRequestHandler<SearchProductQuery, IEnumerable<Product>>
        {
            private readonly StelinaDbContext db;

            public SearchProductQueryHandler(StelinaDbContext db)
            {
                this.db = db;
            }


            public async Task<IEnumerable<Product>> Handle(SearchProductQuery request, CancellationToken cancellationToken)
            {
                var data = await db.Products
                        .Include(p => p.Images)
                        .Where(p => p.Name.Contains(request.SearchTerm) && p.DeletedDate == null)
                        .Select(p => new Product
                        {
                            Id = p.Id,
                            Name = p.Name,
                            Images = p.Images,
                            Price = p.Price

                        })
                        .ToListAsync();

                return data;
            }
        }
        }


    
}
