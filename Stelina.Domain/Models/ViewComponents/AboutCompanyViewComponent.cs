using MediatR;
using Microsoft.AspNetCore.Mvc;
using Stelina.Domain.Business.AboutModule;
using System.Threading.Tasks;

namespace Stelina.Domain.Models.ViewComponents
{
    public class AboutCompanyViewComponent : ViewComponent
    {
        private readonly IMediator mediator;

        public AboutCompanyViewComponent(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var query = new AboutGetAllQuery();

            var response = await mediator.Send(query);

            return View(response);
        }
    }
}
