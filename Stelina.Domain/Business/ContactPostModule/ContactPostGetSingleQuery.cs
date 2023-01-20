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

namespace Stelina.Domain.Business.ContactPostModule
{
    public class ContactPostGetSingleQuery : IRequest<ContactPost>
    {
        public int Id { get; set; }
        public class ContactPostGetSingleQueryHandler : IRequestHandler<ContactPostGetSingleQuery, ContactPost>
        {
            private readonly StelinaDbContext db;

            public ContactPostGetSingleQueryHandler(StelinaDbContext db)
            {
                this.db = db;
            }

            public async Task<ContactPost> Handle(ContactPostGetSingleQuery request, CancellationToken cancellationToken)
            {
                var data = await db.ContactPosts.FirstOrDefaultAsync(p => p.Id == request.Id);

                return data;
            }
        }

    }
}
