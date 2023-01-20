using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Stelina.Domain.Business.ContactDetailModule;
using Stelina.Domain.Models.DataContexts;
using Stelina.Domain.Models.Entities;

namespace Stelina.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactDetailsController : Controller
    {
        private readonly StelinaDbContext db;
        private readonly IMediator mediator;

        public ContactDetailsController(StelinaDbContext db, IMediator mediator)
        {
            this.db = db;
            this.mediator = mediator;
        }

        [Authorize(Policy = "admin.contactdetails.index")]
        public async Task<IActionResult> Index(ContactDetailGetAllQuery query)
        {
            var response = await mediator.Send(query);

            if (response == null)
            {
                return NotFound();
            }

            return View(response);
        }

        [Authorize(Policy = "admin.contactdetails.details")]
        public async Task<IActionResult> Details(ContactDetailGetSingleQuery query)
        {
            var response = await mediator.Send(query);

            if (response == null)
            {
                return NotFound();
            }

            return View(response);
        }

        [Authorize(Policy = "admin.contactdetails.create")]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "admin.contactdetails.create")]
        public async Task<IActionResult> Create(ContactDetailCreateCommand command)
        {
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

        [Authorize(Policy = "admin.contactdetails.edit")]
        public async Task<IActionResult> Edit(int? id, ContactDetailEditCommand command)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entity = await db.ContactDetails
                .FirstOrDefaultAsync(c => c.Id == id);


            if (entity == null)
            {
                return NotFound();
            }


            command.Id = entity.Id;
            command.PhoneNumber = entity.PhoneNumber;
            command.Location = entity.Location;
            command.SupportEmail = entity.SupportEmail;

            return View(command);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "admin.contactdetails.edit")]
        public async Task<IActionResult> Edit(ContactDetailEditCommand command)
        {
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

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "admin.contactdetails.delete")]
        public async Task<IActionResult> DeleteConfirmed(ContactPostRemoveCommand command)
        {
            var response = await mediator.Send(command);

            if (response == null)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool ContactDetailExists(int id)
        {
            return db.ContactDetails.Any(e => e.Id == id);
        }
    }
}
