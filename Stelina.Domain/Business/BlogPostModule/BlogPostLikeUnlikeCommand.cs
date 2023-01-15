using MediatR;
using Microsoft.EntityFrameworkCore;
using Stelina.Domain.AppCode.Infrastructure;
using Stelina.Domain.Models.DataContexts;
using Stelina.Domain.Models.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Stelina.Domain.Business.BlogPostModule
{
    public class BlogPostLikeUnlikeCommand : IRequest<JsonResponse>
    {
        public int BlogPostId { get; set; }

        public int UserId { get; set; }

        public bool isLiked { get; set; }

        public class BlogPostLikeUnlikeCommandHandler : IRequestHandler<BlogPostLikeUnlikeCommand, JsonResponse>
        {
            private readonly StelinaDbContext db;

            public BlogPostLikeUnlikeCommandHandler(StelinaDbContext db)
            {
                this.db = db;
            }

            public async Task<JsonResponse> Handle(BlogPostLikeUnlikeCommand request, CancellationToken cancellationToken)
            {

                #region Check blog post and user

                var blogPost = await db.BlogPosts.FirstOrDefaultAsync(bp => bp.Id == request.BlogPostId, cancellationToken);

                if (blogPost == null)
                {
                    return new JsonResponse
                    {
                        Error = true,
                        Message = "Xətalı sorğu"
                    };
                }


                var user = await db.Users.FirstOrDefaultAsync(u => u.Id == request.UserId);

                if (user == null)
                {
                    return new JsonResponse
                    {
                        Error = true,
                        Message = "Xətalı sorğu"
                    };
                }

                #endregion


                if (request.isLiked)
                {
                    if (await db.BlogPostLikes.AnyAsync(bpl => bpl.BlogPostId == request.BlogPostId && bpl.CreatedByUserId == request.UserId))
                    {
                        return new JsonResponse
                        {
                            Error = false,
                            Message = "Postu bəyənmisiniz"
                        };
                    }
                    else
                    {
                        db.BlogPostLikes.Add(new BlogPostLike
                        {
                            BlogPostId = request.BlogPostId,
                            CreatedByUserId = request.UserId
                        });
                    }

                    await db.SaveChangesAsync();

                    return new JsonResponse
                    {
                        Error = false,
                        Message = "Postu bəyəndiniz"
                    };
                }
                else
                {
                    var blogPostLike = await db.BlogPostLikes.FirstOrDefaultAsync(bpl => bpl.BlogPostId == request.BlogPostId && bpl.CreatedByUserId == request.UserId);

                    if (blogPostLike == null)
                    {
                        return new JsonResponse
                        {
                            Error = true,
                            Message = "Postu bəyənməmisiniz"
                        };
                    }
                    else
                    {
                        db.BlogPostLikes.Remove(blogPostLike);

                        await db.SaveChangesAsync();

                        return new JsonResponse
                        {
                            Error = false,
                            Message = "Postu bəyənməkdən vazkeçdiniz"
                        };
                    }
                    
                }
            }
        }
    }
}
