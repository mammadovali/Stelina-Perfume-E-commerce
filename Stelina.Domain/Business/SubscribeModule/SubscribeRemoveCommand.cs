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

namespace Stelina.Domain.Business.SubscribeModule
{ 
    public class SubscribeRemoveCommand : IRequest<Subscribe>
    {
        public int Id { get; set; }

        public class SubscribeRemoveCommandHandler : IRequestHandler<SubscribeRemoveCommand, Subscribe>
        {
            private readonly StelinaDbContext db;

            public SubscribeRemoveCommandHandler(StelinaDbContext db)
            {
                this.db = db;
            }

            public async Task<Subscribe> Handle(SubscribeRemoveCommand request, CancellationToken cancellationToken)
            {
                var data = await db.Subscribes
                    .FirstOrDefaultAsync(m => m.Id == request.Id && m.DeletedDate == null, cancellationToken);

                if (data == null)
                {
                    return null;
                }

                data.DeletedDate = DateTime.UtcNow.AddHours(4);
                await db.SaveChangesAsync(cancellationToken);

                return data;
            }


        }
    }
    
}
