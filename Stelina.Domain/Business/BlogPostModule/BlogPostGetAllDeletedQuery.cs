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
    public class BlogPostGetAllDeletedQuery : IRequest<List<BlogPost>>
    {
        public class BlogPostGetAllDeletedHandler : IRequestHandler<BlogPostGetAllDeletedQuery, List<BlogPost>>
        {
            private readonly StelinaDbContext db;

            public BlogPostGetAllDeletedHandler(StelinaDbContext db)
            {
                this.db = db;
            }


            public async Task<List<BlogPost>> Handle(BlogPostGetAllDeletedQuery request, CancellationToken cancellationToken)
            {
                var deletedPosts = await db.BlogPosts
                    .Where(bp => bp.DeletedDate != null)
                    .ToListAsync(cancellationToken);


                return deletedPosts;
            }
        }
    }
}
