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
    public class OrderGetAllDeliveredQuery : IRequest<List<Order>>
    {
        public class OrderGetAllDeliveredHandler : IRequestHandler<OrderGetAllDeliveredQuery, List<Order>>
        {
            private readonly StelinaDbContext db;

            public OrderGetAllDeliveredHandler(StelinaDbContext db)
            {
                this.db = db;
            }


            public async Task<List<Order>> Handle(OrderGetAllDeliveredQuery request, CancellationToken cancellationToken)
            {
                var completedOrders = await db.Orders
                    .Where(o => o.DeletedDate == null && o.IsDelivered == true)
                    .ToListAsync(cancellationToken);


                return completedOrders;
            }
        }
    }
}
