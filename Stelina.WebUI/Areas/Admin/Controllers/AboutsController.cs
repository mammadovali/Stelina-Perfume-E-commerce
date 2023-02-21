using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stelina.Domain.Business.AboutModule;
using Stelina.Domain.Models.DataContexts;
using System.Linq;
using System.Threading.Tasks;

namespace Stelina.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutsController : Controller
    {
        private readonly StelinaDbContext db;
        private readonly IMediator mediator;

        public AboutsController(StelinaDbContext db, IMediator mediator)
        {
            this.db = db;
            this.mediator = mediator;
        }

        [Authorize(Policy = "admin.about.index")]
        public async Task<IActionResult> Index(AboutGetAllQuery query)
        {
            var response = await mediator.Send(query);

            if (response == null)
            {
                return NotFound();
            }

            return View(response);
        }

        [Authorize(Policy = "admin.about.details")]
        public async Task<IActionResult> Details(AboutGetSingleQuery query)
        {
            var response = await mediator.Send(query);

            if (response == null)
            {
                return NotFound();
            }

            return View(response);
        }

        [Authorize(Policy = "admin.about.create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "admin.about.create")]
        public async Task<IActionResult> Create(AboutCreateCommand command)
        {
            if (command.Image == null)
            {
                ModelState.AddModelError("ImagePath", "Image should not be left empty");
            }

            if (ModelState.IsValid)
            {
                var response = await mediator.Send(command);

                if (response == null)
                {
                    return NotFound();
                }

                return RedirectToAction(nameof(Index));
            }

            return View(command);
        }

        [Authorize(Policy = "admin.about.edit")]
        public async Task<IActionResult> Edit(int? id, AboutEditCommand command)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entity = await db.AboutCompany
                .FirstOrDefaultAsync(c => c.Id == id);


            if (entity == null)
            {
                return NotFound();
            }

            if (command.Image == null)
            {
                ModelState.AddModelError("ImagePath", "Image should not be left empty");
            }


            command.Id = entity.Id;
            command.ImagePath = entity.ImagePath;
            command.BoldText = entity.BoldText;
            command.NormalText = entity.NormalText;
            command.FreeDeliveryText = entity.FreeDeliveryText;
            command.MoneyGuaranteeText = entity.MoneyGuaranteeText;
            command.OnlineSupportText = entity.OnlineSupportText;

            return View(command);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "admin.about.edit")]
        public async Task<IActionResult> Edit(AboutEditCommand command)
        {
            if (ModelState.IsValid)
            {
                var response = await mediator.Send(command);

                if (response == null)
                {
                    return NotFound();
                }

                if (response.Error == false)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(command);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "admin.about.delete")]
        public async Task<IActionResult> DeleteConfirmed(AboutRemoveCommand command)
        {
            var response = await mediator.Send(command);

            if (response == null)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool AboutExists(int id)
        {
            return db.AboutCompany.Any(e => e.Id == id);
        }
    }
}
