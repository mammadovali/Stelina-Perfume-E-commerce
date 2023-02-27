using MediatR;
using Microsoft.EntityFrameworkCore;
using Stelina.Domain.AppCode.Infrastructure;
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
    public class HomeBackgroundGetAllQuery : PaginateModel, IRequest<List<HomeBackground>>
    {

        public class HomeBackgroundGetAllQueryHandler : IRequestHandler<HomeBackgroundGetAllQuery, List<HomeBackground>>
        {
            private readonly StelinaDbContext db;

            public HomeBackgroundGetAllQueryHandler(StelinaDbContext db)
            {
                this.db = db;
            }
            public async Task<List<HomeBackground>> Handle(HomeBackgroundGetAllQuery request, CancellationToken cancellationToken)
            {

                var query = await db.HomeBackgrounds
                .Where(bp => bp.DeletedDate == null)
                .OrderByDescending(bp => bp.CreatedDate)
                .ToListAsync(cancellationToken);


                return query;
            }
        }
    }
}
