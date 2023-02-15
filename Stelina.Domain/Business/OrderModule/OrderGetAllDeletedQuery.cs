using MediatR;
using Microsoft.EntityFrameworkCore;
using Stelina.Domain.Models.DataContexts;
using Stelina.Domain.Models.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace Stelina.Domain.Business.OrderModule
{
    public class OrderGetAllCancelledQuery : IRequest<List<Order>>
    {
        public class OrderGetAllCancelledHandler : IRequestHandler<OrderGetAllCancelledQuery, List<Order>>
        {
            private readonly StelinaDbContext db;

            public OrderGetAllCancelledHandler(StelinaDbContext db)
            {
                this.db = db;
            }


            public async Task<List<Order>> Handle(OrderGetAllCancelledQuery request, CancellationToken cancellationToken)
            {
                var completedOrders = await db.Orders
                    .Where(o => o.DeletedDate != null)
                    .ToListAsync(cancellationToken);


                return completedOrders;
            }
        }
    }
}
