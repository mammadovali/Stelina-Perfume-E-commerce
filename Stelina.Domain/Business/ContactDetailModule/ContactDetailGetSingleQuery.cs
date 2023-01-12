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

namespace Stelina.Domain.Business.ContactDetailModule
{
    public class ContactDetailGetSingleQuery : IRequest<ContactDetail>
    {
        public int Id { get; set; }
        public class ContactDetailGetSingleQueryHandler : IRequestHandler<ContactDetailGetSingleQuery, ContactDetail>
        {
            private readonly StelinaDbContext db;

            public ContactDetailGetSingleQueryHandler(StelinaDbContext db)
            {
                this.db = db;
            }

            public async Task<ContactDetail> Handle(ContactDetailGetSingleQuery request, CancellationToken cancellationToken)
            {
                var data = await db.ContactDetails.FirstOrDefaultAsync(p => p.Id == request.Id);

                return data;
            }
        }

    }
}
