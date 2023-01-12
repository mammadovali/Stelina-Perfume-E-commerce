using MediatR;
using Microsoft.EntityFrameworkCore;
using Stelina.Domain.Models.DataContexts;
using Stelina.Domain.Models.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Stelina.Domain.Business.ContactDetailModule
{


    public class ContactDetailRemoveCommand : IRequest<ContactDetail>
    {
        public int Id { get; set; }

        public class ContactDetailRemoveCommandHandler : IRequestHandler<ContactDetailRemoveCommand, ContactDetail>
        {
            private readonly StelinaDbContext db;

            public ContactDetailRemoveCommandHandler(StelinaDbContext db)
            {
                this.db = db;
            }

            public async Task<ContactDetail> Handle(ContactDetailRemoveCommand request, CancellationToken cancellationToken)
            {
                var data = await db.ContactDetails
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
