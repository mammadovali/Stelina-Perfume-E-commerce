using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Stelina.Domain.AppCode.Extensions;
using Stelina.Domain.Business.BlogPostModule;
using Stelina.Domain.Models.DataContexts;
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
            var entity = await mediator.Send(query);

            if (entity == null)
            {
                return NotFound();
            }

            return View(entity);
        }

        [HttpPost]
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

    }
}
