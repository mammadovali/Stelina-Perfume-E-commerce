using Stelina.Domain.Business.BlogPostModule;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Stelina.WebUI.Models.AppCode.ViewComponents
{
    public class RecentPostsHomeViewComponent : ViewComponent
    {
        private readonly IMediator mediator;

        public RecentPostsHomeViewComponent(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var query = new BlogPostRecentQuery() { Size = 4 };

            var posts = await mediator.Send(query);

            return View(posts);
        }
    }
}
