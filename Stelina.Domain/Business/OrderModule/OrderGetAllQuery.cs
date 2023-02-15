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

    public class OrderGetAllQuery : IRequest<List<Order>>
    {
        public class OrderGetAllQueryHandler : IRequestHandler<OrderGetAllQuery, List<Order>>
        {
            private readonly StelinaDbContext db;

            public OrderGetAllQueryHandler(StelinaDbContext db)
            {
                this.db = db;
            }
            public async Task<List<Order>> Handle(OrderGetAllQuery request, CancellationToken cancellationToken)
            {
                var data = await db.Orders
                .Where(o => o.DeletedDate == null && o.IsDelivered == false)
                .ToListAsync(cancellationToken);

                return data;
            }
        }


    }
}
