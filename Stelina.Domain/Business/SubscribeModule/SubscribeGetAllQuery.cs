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

namespace Stelina.Domain.Business.SubscribeModule
{

    public class SubscribeGetAllQuery : IRequest<List<Subscribe>>
    {
        public class SubscribeGetAllQueryHandler : IRequestHandler<SubscribeGetAllQuery, List<Subscribe>>
        {
            private readonly StelinaDbContext db;

            public SubscribeGetAllQueryHandler(StelinaDbContext db)
            {
                this.db = db;
            }
            public async Task<List<Subscribe>> Handle(SubscribeGetAllQuery request, CancellationToken cancellationToken)
            {
                var data = await db.Subscribes
                .Where(bp => bp.DeletedDate == null)
                .ToListAsync(cancellationToken);

                return data;
            }
        }


    }
}
