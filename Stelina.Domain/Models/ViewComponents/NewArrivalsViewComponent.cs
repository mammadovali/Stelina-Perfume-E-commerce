using MediatR;
using Microsoft.AspNetCore.Mvc;
using Stelina.Domain.Business.ProductModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stelina.Domain.Models.ViewComponents
{
    public class NewArrivalsViewComponent : ViewComponent
    {
        private readonly IMediator mediator;

        public NewArrivalsViewComponent(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var query = new NewArrivalsQuery();

            var response = await mediator.Send(query);

            return View(response);
        }
    }
}
