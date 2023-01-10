using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Stelina.Domain.Business.SubscribeModule;
using Stelina.Domain.Models.DataContexts;
using Stelina.Domain.Models.Entities;

namespace Stelina.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SubscribesController : Controller
    {
        private readonly StelinaDbContext db;
        private readonly IMediator mediator;

        public SubscribesController(StelinaDbContext db, IMediator mediator)
        {
            this.db = db;
            this.mediator = mediator;
        }

        // GET: Admin/Subscribes
        public async Task<IActionResult> Index(SubscribeGetAllQuery query)
        {
            var response = await mediator.Send(query);

            if (response == null)
            {
                return NotFound();
            }

            return View(response);
        }


        // POST: Admin/Subscribes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(SubscribeRemoveCommand command)
        {
            var response = await mediator.Send(command);

            if (response == null)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool SubscribeExists(int id)
        {
            return db.Subscribes.Any(e => e.Id == id);
        }
    }
}
