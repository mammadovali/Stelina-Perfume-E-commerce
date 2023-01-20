using MediatR;
using Microsoft.EntityFrameworkCore;
using Stelina.Domain.Models.DataContexts;
using Stelina.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Stelina.Domain.Business.ContactDetailModule
{

    public class ContactDetailEditCommand : IRequest<ContactDetail>
    {
        public int Id { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Location { get; set; }


        [Required]
        public string SupportEmail { get; set; }

        public class ContactDetailEditCommandHandler : IRequestHandler<ContactDetailEditCommand, ContactDetail>
        {
            private readonly StelinaDbContext db;

            public ContactDetailEditCommandHandler(StelinaDbContext db)
            {
                this.db = db;
            }

            public async Task<ContactDetail> Handle(ContactDetailEditCommand request, CancellationToken cancellationToken)
            {
                var data = await db.ContactDetails
                    .FirstOrDefaultAsync(m => m.Id == request.Id && m.DeletedDate == null, cancellationToken);

                if (data == null)
                {
                    return null;
                }

                data.PhoneNumber = request.PhoneNumber;

                data.Location = request.Location;

                data.SupportEmail = request.SupportEmail;

                await db.SaveChangesAsync(cancellationToken);

                return data;
            }


        }
    }
}
