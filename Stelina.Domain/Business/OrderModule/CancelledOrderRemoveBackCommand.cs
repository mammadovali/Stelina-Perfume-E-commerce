
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Stelina.Domain.Models.Entities;
using Stelina.Domain.Models.DataContexts;

namespace Stelina.Domain.Business.OrderModule
{
    public class CancelledOrderRemoveBackCommand : IRequest<Order>
    {
        public int Id { get; set; }
        public class CancelledOrderRemoveBackCommandHandler : IRequestHandler<CancelledOrderRemoveBackCommand, Order>
        {
            private readonly StelinaDbContext db;

            public CancelledOrderRemoveBackCommandHandler(StelinaDbContext db)
            {
                this.db = db;
            }

            public async Task<Order> Handle(CancelledOrderRemoveBackCommand request, CancellationToken cancellationToken)
            {
                var data = db.Orders.FirstOrDefault(m => m.Id == request.Id && m.DeletedDate != null);

                if (data == null)
                {
                    return null;
                }

                data.DeletedDate = null;
                data.IsDelivered = false;

                await db.SaveChangesAsync(cancellationToken);
                return data;
            }
        }
    }
}

