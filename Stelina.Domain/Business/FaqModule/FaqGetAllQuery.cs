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

namespace Stelina.Domain.Business.FaqModule
{
    
    public class FaqGetAllQuery : IRequest<List<Faq>>
    {
        public class FaqGetAllQueryHandler : IRequestHandler<FaqGetAllQuery, List<Faq>>
        {
            private readonly StelinaDbContext db;

            public FaqGetAllQueryHandler(StelinaDbContext db)
            {
                this.db = db;
            }
            public async Task<List<Faq>> Handle(FaqGetAllQuery request, CancellationToken cancellationToken)
            {
                var data = await db.Faqs
                .Where(bp => bp.DeletedDate == null)
                .ToListAsync(cancellationToken);

                return data;
            }
        }


    }
}
