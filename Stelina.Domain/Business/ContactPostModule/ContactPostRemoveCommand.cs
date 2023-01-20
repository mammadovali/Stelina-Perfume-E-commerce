using MediatR;
using Microsoft.EntityFrameworkCore;
using Stelina.Domain.Models.DataContexts;
using Stelina.Domain.Models.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Stelina.Domain.Business.ContactPostModule
{
    public class ContactPostRemoveCommand : IRequest<ContactPost>
    {
        public int Id { get; set; }

        public class ContactPostRemoveCommandHandler : IRequestHandler<ContactPostRemoveCommand, ContactPost>
        {
            private readonly StelinaDbContext db;

            public ContactPostRemoveCommandHandler(StelinaDbContext db)
            {
                this.db = db;
            }

            public async Task<ContactPost> Handle(ContactPostRemoveCommand request, CancellationToken cancellationToken)
            {
                var data = await db.ContactPosts
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
