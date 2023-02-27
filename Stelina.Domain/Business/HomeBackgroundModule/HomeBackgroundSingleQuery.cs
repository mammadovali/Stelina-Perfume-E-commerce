using MediatR;
using Microsoft.EntityFrameworkCore;
using Stelina.Domain.Models.DataContexts;
using Stelina.Domain.Models.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Stelina.Domain.Business.HomeBackgroundModule
{
    public class HomeBackgroundSingleQuery : IRequest<HomeBackground>
    {
        public int Id { get; set; }

        public class HomeBackgroundSingleQueryHandler : IRequestHandler<HomeBackgroundSingleQuery, HomeBackground>
        {
            private readonly StelinaDbContext db;

            public HomeBackgroundSingleQueryHandler(StelinaDbContext db)
            {
                this.db = db;
            }

            public async Task<HomeBackground> Handle(HomeBackgroundSingleQuery request, CancellationToken cancellationToken)
            {
                var query = await db.HomeBackgrounds.FirstOrDefaultAsync(m => m.Id == request.Id && m.DeletedDate == null);

                return query;
            }
        }

    }
}
