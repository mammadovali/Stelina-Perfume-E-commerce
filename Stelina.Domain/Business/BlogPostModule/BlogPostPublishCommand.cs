using MediatR;
using Microsoft.EntityFrameworkCore;
using Stelina.Domain.Models.DataContexts;
using Stelina.Domain.Models.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Stelina.Domain.Business.BlogPostModule
{
    public class BlogPostPublishCommand : IRequest<BlogPost>
    {
        public int Id { get; set; }
        public class BlogPostPublishCommandHandler : IRequestHandler<BlogPostPublishCommand, BlogPost>
        {
            private readonly StelinaDbContext db;

            public BlogPostPublishCommandHandler(StelinaDbContext db)
            {
                this.db = db;
            }

            public async Task<BlogPost> Handle(BlogPostPublishCommand request, CancellationToken cancellationToken)
            {
                var data = await db.BlogPosts.FirstOrDefaultAsync(bp => bp.Id == request.Id && bp.PublishedDate == null);

                if (data == null)
                {
                    return null;
                }

                data.PublishedDate = DateTime.UtcNow.AddHours(4);
                await db.SaveChangesAsync(cancellationToken);

                return data;
            }
        }

    }
}
