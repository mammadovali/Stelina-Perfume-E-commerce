using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stelina.Domain.Business.HomeBackgroundModule;
using Stelina.Domain.Models.DataContexts;
using System.Linq;
using System.Threading.Tasks;

namespace Stelina.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeBackgroundsController : Controller
    {
        private readonly StelinaDbContext db;

        public IMediator mediator { get; }

        public HomeBackgroundsController(StelinaDbContext db, IMediator mediator)
        {
            this.db = db;
            this.mediator = mediator;
        }

        [Authorize(Policy = "admin.homebackgrounds.index")]
        public async Task<IActionResult> Index(HomeBackgroundGetAllQuery query)
        {
            var response = await mediator.Send(query);

            if (response == null)
            {
                return NotFound();
            }

            return View(response);
        }

        [Authorize(Policy = "admin.homebackgrounds.details")]
        public async Task<IActionResult> Details(HomeBackgroundSingleQuery query)
        {
            var response = await mediator.Send(query);

            if (response == null)
            {
                return NotFound();
            }

            return View(response);
        }


        [Authorize(Policy = "admin.homebackgrounds.create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "admin.homebackgrounds.create")]
        public async Task<IActionResult> Create(HomeBackgroundCreateCommand command)
        {

            if (command.Image == null)
            {
                ModelState.AddModelError("ImagePath", "Background image should not be left empty");
            }

            if (ModelState.IsValid)
            {
                var response = await mediator.Send(command);

                return RedirectToAction(nameof(Index));
            }

            return View(command);
        }

        [Authorize(Policy = "admin.homebackgrounds.edit")]
        public async Task<IActionResult> Edit(int? id, HomeBackgroundEditCommand command)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entity = await db.HomeBackgrounds
                .FirstOrDefaultAsync(bp => bp.Id == id);
            if (entity == null)
            {
                return NotFound();
            }


            command.Id = entity.Id;
            command.Text = entity.Text;
            command.ImagePath = entity.ImagePath;


            return View(command);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "admin.homebackgrounds.edit")]
        public async Task<IActionResult> Edit(HomeBackgroundEditCommand command)
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
        [Authorize(Policy = "admin.homebackgrounds.delete")]
        public async Task<IActionResult> DeleteConfirmed(HomeBackgroundRemoveCommand command)
        {
            var response = await mediator.Send(command);

            if (response == null)
            {
                return NotFound();
            }


            return RedirectToAction(nameof(Index));
        }


        private bool HomeBackgroundExists(int id)
        {
            return db.HomeBackgrounds.Any(e => e.Id == id);
        }
    }
}
