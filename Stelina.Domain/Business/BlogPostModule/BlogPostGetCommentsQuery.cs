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

namespace Stelina.Domain.Business.BlogPostModule
{
    public class BlogPostGetCommentsQuery : IRequest<List<BlogPostComment>>
    {
        public int BlogPostId { get; set; }
        public class BlogPostGetCommentsQueryHandler : IRequestHandler<BlogPostGetCommentsQuery, List<BlogPostComment>>
        {
            private readonly StelinaDbContext db;

            public BlogPostGetCommentsQueryHandler(StelinaDbContext db)
            {
                this.db = db;
            }

            public async Task<List<BlogPostComment>> Handle(BlogPostGetCommentsQuery request, CancellationToken cancellationToken)
            {
                var data = await db.BlogPostComments
                    .Include(bpc => bpc.BlogPost)
                    .Include(bpc=>bpc.CreatedByUser)
                    .Where(bpc => bpc.DeletedDate == null && bpc.BlogPostId == request.BlogPostId)
                    .ToListAsync();

                return data;
            }
        }
    }
}
