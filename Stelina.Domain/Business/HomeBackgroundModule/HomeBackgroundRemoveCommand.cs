using MediatR;
using Stelina.Domain.Models.DataContexts;
using Stelina.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Stelina.Domain.Business.HomeBackgroundModule
{

    public class HomeBackgroundRemoveCommand : IRequest<HomeBackground>
    {
        public int Id { get; set; }

        public class HomeBackgroundRemoveCommandHandler : IRequestHandler<HomeBackgroundRemoveCommand, HomeBackground>
        {
            private readonly StelinaDbContext db;

            public HomeBackgroundRemoveCommandHandler(StelinaDbContext db)
            {
                this.db = db;
            }

            public async Task<HomeBackground> Handle(HomeBackgroundRemoveCommand request, CancellationToken cancellationToken)
            {
                var data = db.HomeBackgrounds.FirstOrDefault(m => m.Id == request.Id && m.DeletedDate == null);

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
