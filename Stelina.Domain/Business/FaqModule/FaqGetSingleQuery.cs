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
    public class FaqGetSingleQuery : IRequest<Faq>
    {
        public int Id { get; set; }

        public class FaqGetSingleQueryHandler : IRequestHandler<FaqGetSingleQuery, Faq>
        {
            private readonly StelinaDbContext db;

            public FaqGetSingleQueryHandler(StelinaDbContext db)
            {
                this.db = db;
            }

            public async Task<Faq> Handle(FaqGetSingleQuery request, CancellationToken cancellationToken)
            {
                var data = await db.Faqs.FirstOrDefaultAsync(p => p.Id == request.Id);

                return data;
            }
        }

    }
}
