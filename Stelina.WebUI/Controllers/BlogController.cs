using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stelina.Domain.AppCode.Extensions;
using Stelina.Domain.Business.BlogPostModule;
using Stelina.Domain.Models.DataContexts;
using Stelina.Domain.Models.ViewModels.BlogPostItems;
using System.Linq;
using System.Threading.Tasks;

namespace Stelina.WebUI.Controllers
{

    public class BlogController : Controller
    {
        private readonly StelinaDbContext db;
        private readonly IMediator mediator;

        public BlogController(StelinaDbContext db, IMediator mediator)
        {
            this.db = db;
            this.mediator = mediator;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index(BlogPostGetAllQuery query)
        {
            var response = await mediator.Send(query);

            if (Request.IsAjaxRequest())
            {
                return PartialView("_PostBody", response);
            }

            if (response == null)
            {
                return NotFound();
            }
            return View(response);
        }

        [AllowAnonymous]
        [Route("/blog/{slug}")]
        public async Task<IActionResult> Details(BlogPostSingleQuery query)
        {
            var blogPost = await mediator.Send(query);

            var blogPostLikes = await db.BlogPostLikes.Where(bpl => bpl.BlogPostId == blogPost.Id).ToListAsync();

            var vm = new BlogPostItemsViewModel()
            {
                BlogPost = blogPost,
                BlogPostLikes = blogPostLikes
            };

            return View(vm);
        }

        [HttpPost]
        [Route("/post-comment")]
        public async Task<IActionResult> PostComment(BlogPostCommentCommand command)
        {
            try
            {
                var response = await mediator.Send(command);

                return PartialView("_Comment", response);
            }
            catch (System.Exception ex)
            {
                return Json(new
                {
                    error = true,
                    message = ex.Message
                });
            }

        }

        [HttpPost]
        [Route("/like-unlike-blog-post")]
        public async Task<IActionResult> LikeUnlikeBlogPost(BlogPostLikeUnlikeCommand command)
        {
            var response = await mediator.Send(command);

            if (response == null)
            {
                return NotFound();
            }

            return Json(response);
        }
    }
}
