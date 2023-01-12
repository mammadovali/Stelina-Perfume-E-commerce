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
    
    public class ContactDetailGetAllQuery : IRequest<List<ContactDetail>>
    {
        public class ContactDetailGetAllQueryHandler : IRequestHandler<ContactDetailGetAllQuery, List<ContactDetail>>
        {
            private readonly StelinaDbContext db;

            public ContactDetailGetAllQueryHandler(StelinaDbContext db)
            {
                this.db = db;
            }
            public async Task<List<ContactDetail>> Handle(ContactDetailGetAllQuery request, CancellationToken cancellationToken)
            {
                var data = await db.ContactDetails
                .Where(bp => bp.DeletedDate == null)
                .ToListAsync(cancellationToken);

                return data;
            }
        }


    }
}
