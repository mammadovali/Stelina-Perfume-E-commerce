using MediatR;
using Microsoft.EntityFrameworkCore;
using Stelina.Domain.Models.DataContexts;
using Stelina.Domain.Models.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Stelina.Domain.Business.BlogPostModule
{
    public class BlogPostGetSingleCommentQuery : IRequest<BlogPostComment>
    {
        public int Id { get; set; }
        public class BlogPostGetSingleCommentQueryHandler : IRequestHandler<BlogPostGetSingleCommentQuery, BlogPostComment>
        {
            private readonly StelinaDbContext db;

            public BlogPostGetSingleCommentQueryHandler(StelinaDbContext db)
            {
                this.db = db;
            }

            public async Task<BlogPostComment> Handle(BlogPostGetSingleCommentQuery request, CancellationToken cancellationToken)
            {
                var data = await db.BlogPostComments
                    .Include(bpc=>bpc.CreatedByUser)
                    .FirstOrDefaultAsync(bpc => bpc.Id == request.Id);

                return data;
            }
        }
    }
}
