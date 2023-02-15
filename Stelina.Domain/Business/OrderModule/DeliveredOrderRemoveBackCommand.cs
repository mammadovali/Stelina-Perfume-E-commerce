using MediatR;
using Stelina.Domain.Models.DataContexts;
using Stelina.Domain.Models.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Stelina.Domain.Business.OrderModule
{
    public class DeliveredOrderRemoveBackCommand : IRequest<Order>
    {
        public int Id { get; set; }
        public class DeliveredOrderRemoveBackCommandHandler : IRequestHandler<DeliveredOrderRemoveBackCommand, Order>
        {
            private readonly StelinaDbContext db;

            public DeliveredOrderRemoveBackCommandHandler(StelinaDbContext db)
            {
                this.db = db;
            }

            public async Task<Order> Handle(DeliveredOrderRemoveBackCommand request, CancellationToken cancellationToken)
            {
                var data = db.Orders.FirstOrDefault(m => m.Id == request.Id && m.IsDelivered == true);

                if (data == null)
                {
                    return null;
                }

                data.IsDelivered = false;

                await db.SaveChangesAsync(cancellationToken);
                return data;
            }
        }
    }
}

