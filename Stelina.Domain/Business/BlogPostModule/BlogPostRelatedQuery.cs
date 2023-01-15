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
    public class BlogPostRelatedQuery : IRequest<List<BlogPost>>
    {
        public int Size { get; set; }

        public int PostId { get; set; }
        public class BlogPostRelatedQueryHandler : IRequestHandler<BlogPostRelatedQuery, List<BlogPost>>
        {
            private readonly StelinaDbContext db;

            public BlogPostRelatedQueryHandler(StelinaDbContext db)
            {
                this.db = db;
            }
            public async Task<List<BlogPost>> Handle(BlogPostRelatedQuery request, CancellationToken cancellationToken)
            {
                //baxdigimiz postun oldugu tag ler
                var tagIds = await db.BlogPostTagCloud.Where(bptc => bptc.BlogPostId == request.PostId)
                    .Select(bptc => bptc.TagId).ToArrayAsync(cancellationToken);


                var posts = await (from bp in db.BlogPosts.Where(bp => bp.DeletedDate == null)
                             join bptc in db.BlogPostTagCloud on bp.Id equals bptc.BlogPostId
                             where bp.Id != request.PostId && tagIds.Contains(bptc.TagId)
                             select bp)
                             .Distinct()
                             .Take(request.Size < 2 ? 2 : request.Size)
                             .ToListAsync(cancellationToken);

                return posts;
            }
        }
    }


}
