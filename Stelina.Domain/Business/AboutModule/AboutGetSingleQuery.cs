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

namespace Stelina.Domain.Business.AboutModule
{
    public class AboutGetSingleQuery : IRequest<About>
    {
        public int Id { get; set; }

        public class AboutGetSingleQueryHandler : IRequestHandler<AboutGetSingleQuery, About>
        {
            private readonly StelinaDbContext db;

            public AboutGetSingleQueryHandler(StelinaDbContext db)
            {
                this.db = db;
            }

            public async Task<About> Handle(AboutGetSingleQuery request, CancellationToken cancellationToken)
            {
                var data = await db.AboutCompany
                    .FirstOrDefaultAsync(p => p.Id == request.Id);

                return data;
            }
        }

    }
}
