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

namespace Stelina.Domain.Business.TagModule
{
    public class TagGetSingleQuery : IRequest<Tag>
    {
        public int Id { get; set; }

        public class TagGetSingleQueryHandler : IRequestHandler<TagGetSingleQuery, Tag>
        {
            private readonly StelinaDbContext db;

            public TagGetSingleQueryHandler(StelinaDbContext db)
            {
                this.db = db;
            }

            public async Task<Tag> Handle(TagGetSingleQuery request, CancellationToken cancellationToken)
            {
                var data = await db.Tags
                    .FirstOrDefaultAsync(p => p.Id == request.Id);

                return data;
            }
        }

    }
}
