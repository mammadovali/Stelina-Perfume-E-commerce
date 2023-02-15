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

namespace Stelina.Domain.Business.OrderModule
{
    public class OrderGetSingleQuery : IRequest<Order>
    {
        public int Id { get; set; }

        public class OrderGetSingleQueryHandler : IRequestHandler<OrderGetSingleQuery, Order>
        {
            private readonly StelinaDbContext db;

            public OrderGetSingleQueryHandler(StelinaDbContext db)
            {
                this.db = db;
            }

            public async Task<Order> Handle(OrderGetSingleQuery request, CancellationToken cancellationToken)
            {
                var data = await db.Orders
                    .Include(o => o.User)
                    .Include(o => o.OrderProducts.Where(op => op.DeletedDate == null))
                    .ThenInclude(op => op.Product)
                    .ThenInclude(p => p.Images.Where(i => i.DeletedDate == null && i.IsMain == true))
                    .FirstOrDefaultAsync(p => p.Id == request.Id);

                return data;
            }
        }

    }
}
