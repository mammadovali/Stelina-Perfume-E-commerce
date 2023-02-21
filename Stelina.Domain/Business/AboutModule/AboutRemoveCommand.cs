using MediatR;
using Stelina.Domain.Models.DataContexts;
using Stelina.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Stelina.Domain.Business.AboutModule
{

    public class AboutRemoveCommand : IRequest<About>
    {
        public int Id { get; set; }

        public class AboutRemoveCommandHandler : IRequestHandler<AboutRemoveCommand, About>
        {
            private readonly StelinaDbContext db;

            public AboutRemoveCommandHandler(StelinaDbContext db)
            {
                this.db = db;
            }

            public async Task<About> Handle(AboutRemoveCommand request, CancellationToken cancellationToken)
            {
                var data = db.AboutCompany.FirstOrDefault(m => m.Id == request.Id && m.DeletedDate == null);

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
