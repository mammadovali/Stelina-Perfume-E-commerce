using MediatR;
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
    public class ContactDetailCreateCommand : IRequest<ContactDetail>
    {
        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public string SupportEmail { get; set; }


        public class ContactDetailCreateCommandHandler : IRequestHandler<ContactDetailCreateCommand, ContactDetail>
        {
            private readonly StelinaDbContext db;

            public ContactDetailCreateCommandHandler(StelinaDbContext db)
            {
                this.db = db;
            }

            public async Task<ContactDetail> Handle(ContactDetailCreateCommand request, CancellationToken cancellationToken)
            {
                var model = new ContactDetail();

                model.PhoneNumber = request.PhoneNumber;

                model.Location = request.Location;

                model.SupportEmail = request.SupportEmail;

                await db.ContactDetails.AddAsync(model, cancellationToken);

                await db.SaveChangesAsync(cancellationToken);

                return model;
            }


        }
    }

}
