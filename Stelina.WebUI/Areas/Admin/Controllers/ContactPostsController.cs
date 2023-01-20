using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Stelina.Domain.AppCode.Services;
using Stelina.Domain.Business.ContactPostModule;
using Stelina.Domain.Models.DataContexts;
using Stelina.Domain.Models.Entities;

namespace Stelina.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactPostsController : Controller
    {
        private readonly StelinaDbContext db;
        private readonly EmailService emailService;
        private readonly IMediator mediator;

        public ContactPostsController(StelinaDbContext db, EmailService emailService, IMediator mediator)
        {
            this.db = db;
            this.emailService = emailService;
            this.mediator = mediator;
        }

        [Authorize(Policy = "admin.contactposts.index")]
        public async Task<IActionResult> Index(ContactPostGetAllQuery query)
        {
            var response = await mediator.Send(query);

            if (response == null)
            {
                return NotFound();
            }

            return View(response);
        }




        [Authorize(Policy = "admin.contactposts.details")]
        public async Task<IActionResult> Details(ContactPostGetSingleQuery query)
        {
            var response = await mediator.Send(query);

            if (response == null)
            {
                return NotFound();
            }

            return View(response);
        }


        [Authorize(Policy = "admin.contactposts.delete")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(ContactPostRemoveCommand command)
        {
            var response = await mediator.Send(command);

            if (response == null)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }


        [Authorize(Policy = "admin.contactposts.reply")]
        public async Task<IActionResult> Reply(int? id)
        {
            if (id == null)
            {
                NotFound();
            }

            var entity = await db.ContactPosts.FirstOrDefaultAsync(cp => cp.Id == id);

            if (entity == null)
            {
                return NotFound();
            }

            return View(entity);
        }




        [HttpPost]
        [Authorize(Policy = "admin.contactposts.reply")]
        public async Task<IActionResult> Reply(int id, [FromForm][Bind("Name, Email, Content, Subject, Answer, EmailSubject")] ContactPost model)
        {
            var entity = db.ContactPosts.FirstOrDefault(bp => bp.Id == id && bp.AnswerDate == null);

            if (!ModelState.IsValid)
            {
                return Json(new
                {
                    error = true,
                    message = "Xəta baş verdi"
                });
            }

            entity.AnswerDate = DateTime.UtcNow.AddHours(4);
            entity.Answer = model.Answer;
            entity.EmailSubject = model.EmailSubject;
            await db.SaveChangesAsync();

            await emailService.SendEmailAsync(model.Email, "Response from Stelina online service", model.Answer);

            return Json(new
            {
                error = false,
                message = "Cavabınız uğurla göndərildi"
            });
        }




        private bool ContactPostExists(int id)
        {
            return db.ContactPosts.Any(e => e.Id == id);
        }
    }
}
