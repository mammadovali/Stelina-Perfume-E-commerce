using MediatR;
using Microsoft.EntityFrameworkCore;
using Stelina.Domain.Models.DataContexts;
using Stelina.Domain.Models.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Stelina.Domain.Business.FaqModule
{


    public class FaqRemoveCommand : IRequest<Faq>
    {
        public int Id { get; set; }

        public class FaqRemoveCommandHandler : IRequestHandler<FaqRemoveCommand, Faq>
        {
            private readonly StelinaDbContext db;

            public FaqRemoveCommandHandler(StelinaDbContext db)
            {
                this.db = db;
            }

            public async Task<Faq> Handle(FaqRemoveCommand request, CancellationToken cancellationToken)
            {
                var data = await db.Faqs
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
