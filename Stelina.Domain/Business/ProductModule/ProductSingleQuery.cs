using MediatR;
using Microsoft.EntityFrameworkCore;
using Stelina.Domain.Models.DataContexts;
using Stelina.Domain.Models.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Stelina.Domain.Business.ProductModule
{
    public class ProductSingleQuery : IRequest<Product>
    {
        public int Id { get; set; }

        public class ProductSingleQueryHandler : IRequestHandler<ProductSingleQuery, Product>
        {
            private readonly StelinaDbContext db;

            public ProductSingleQueryHandler(StelinaDbContext db)
            {
                this.db = db;
            }
            public async Task<Product> Handle(ProductSingleQuery request, CancellationToken cancellationToken)
            {
                var data = await db.Products
                    .Include(p => p.Brand)
                    .Include(p => p.Category)
                    .Include(p=>p.Images.Where(i=>i.DeletedDate == null))
                    .FirstOrDefaultAsync(m => m.Id == request.Id && m.DeletedDate == null,cancellationToken);

                return data;
            }
        }
    }
}
