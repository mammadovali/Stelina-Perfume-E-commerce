using MediatR;
using Microsoft.EntityFrameworkCore;
using Stelina.Domain.AppCode.Infrastructure;
using Stelina.Domain.Models.DataContexts;
using Stelina.Domain.Models.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Stelina.Domain.Business.ProductModule
{
    public class ProductsPagedQuery : PaginateModel, IRequest<PagedViewModel<Product>>
    {
        public class ProductsPagedQueryHandler : IRequestHandler<ProductsPagedQuery, PagedViewModel<Product>>
        {
            private readonly StelinaDbContext db;

            public ProductsPagedQueryHandler(StelinaDbContext db)
            {
                this.db = db;
            }

            public async Task<PagedViewModel<Product>> Handle(ProductsPagedQuery request, CancellationToken cancellationToken)
            {
                var query = db.Products
                    .Include(p => p.Images)
                    .Include(p => p.Brand)
                    .Include(p => p.Category)

                    .Where(m => m.DeletedDate == null)
                    .OrderByDescending(p => p.Id)
                    .AsQueryable();

                var pagedData = new PagedViewModel<Product>(query, request);

                return pagedData;
            }
        }
    }
}
