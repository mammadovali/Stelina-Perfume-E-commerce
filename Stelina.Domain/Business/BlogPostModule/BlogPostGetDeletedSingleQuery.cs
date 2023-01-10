using MediatR;
using Microsoft.EntityFrameworkCore;
using Stelina.Domain.Models.DataContexts;
using Stelina.Domain.Models.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Stelina.Domain.Business.BlogPostModule
{
    public class BlogPostGetDeletedSingleQuery : IRequest<BlogPost>
    {
        public int Id { get; set; }
        public string Slug { get; set; }
        public class BlogPostGetSingleQueryHandler : IRequestHandler<BlogPostGetDeletedSingleQuery, BlogPost>
        {
            private readonly StelinaDbContext db;

            public BlogPostGetSingleQueryHandler(StelinaDbContext db)
            {
                this.db = db;
            }

            public async Task<BlogPost> Handle(BlogPostGetDeletedSingleQuery request, CancellationToken cancellationToken)
            {
                var query = db.BlogPosts
                    .Include(bp => bp.Comments)
                    .AsQueryable();
                if (string.IsNullOrWhiteSpace(request.Slug))
                {
                    return await query.FirstOrDefaultAsync(bp => bp.Id == request.Id && bp.DeletedDate != null, cancellationToken);

                }
                return await query.FirstOrDefaultAsync(bp => bp.Slug.Equals(request.Slug), cancellationToken);
            }
        }
    }
}
