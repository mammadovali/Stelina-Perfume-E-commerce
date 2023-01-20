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
    
    public class ContactPostGetAllQuery : IRequest<List<ContactPost>>
    {
        public class ContactPostGetAllQueryHandler : IRequestHandler<ContactPostGetAllQuery, List<ContactPost>>
        {
            private readonly StelinaDbContext db;

            public ContactPostGetAllQueryHandler(StelinaDbContext db)
            {
                this.db = db;
            }
            public async Task<List<ContactPost>> Handle(ContactPostGetAllQuery request, CancellationToken cancellationToken)
            {
                var data = await db.ContactPosts
                .Where(bp => bp.DeletedDate == null)
                .ToListAsync(cancellationToken);

                return data;
            }
        }


    }
}
