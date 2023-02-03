using MediatR;
using Microsoft.AspNetCore.Mvc;
using Stelina.Domain.Business.ProductModule;
using Stelina.Domain.Models.DataContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stelina.Domain.Models.ViewComponents
{
    public class BasketInfoViewComponent : ViewComponent
    {
        private readonly IMediator mediator;

        public BasketInfoViewComponent(IMediator mediator)
        {
            this.mediator = mediator;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            var query = new ProductBasketQuery();

            var response = await mediator.Send(query);

            return View(response);
        }
    }
}
