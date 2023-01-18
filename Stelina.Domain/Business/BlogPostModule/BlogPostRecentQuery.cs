using MediatR;
using Microsoft.EntityFrameworkCore;
using Stelina.Domain.Models.DataContexts;
using Stelina.Domain.Models.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Stelina.Domain.Business.BlogPostModule
{
    public class BlogPostRecentQuery : IRequest<List<BlogPost>>
    {
        public int Size { get; set; }

        public class BlogPostRecentQueryHandler : IRequestHandler<BlogPostRecentQuery, List<BlogPost>>
        {
            private readonly StelinaDbContext db;

            public BlogPostRecentQueryHandler(StelinaDbContext db)
            {
                this.db = db;
            }
            public async Task<List<BlogPost>> Handle(BlogPostRecentQuery request, CancellationToken cancellationToken)
            {
                var posts = await db.BlogPosts
                  .Where(bp => bp.DeletedDate == null && bp.PublishedDate != null)
                  .OrderByDescending(bp => bp.PublishedDate)
                  .Take(request.Size < 2 ? 2 : request.Size)
                  .ToListAsync(cancellationToken);

                return posts;
            }
        }
    }


}
