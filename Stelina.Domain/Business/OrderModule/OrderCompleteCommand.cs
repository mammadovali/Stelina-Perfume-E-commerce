using MediatR;
using Microsoft.EntityFrameworkCore;
using Stelina.Domain.Models.DataContexts;
using Stelina.Domain.Models.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Stelina.Domain.Business.OrderModule
{
    public class OrderCompleteCommand : IRequest<Order>
    {
        public int Id { get; set; }

        public class OrderCompleteCommandHandler : IRequestHandler<OrderCompleteCommand, Order>
        {
            private readonly StelinaDbContext db;

            public OrderCompleteCommandHandler(StelinaDbContext db)
            {
                this.db = db;
            }

            public async Task<Order> Handle(OrderCompleteCommand request, CancellationToken cancellationToken)
            {
                var data = await db.Orders.FirstOrDefaultAsync(o => o.Id == request.Id && o.DeletedDate == null);

                if (data == null)
                {
                    return null;
                }

                data.IsDelivered = true;
                await db.SaveChangesAsync(cancellationToken);

                return data;
            }
        }

    }
}
