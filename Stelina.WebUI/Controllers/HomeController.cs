using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Serilog;
using Stelina.Domain.AppCode.Extensions;
using Stelina.Domain.AppCode.Services;
using Stelina.Domain.Business.HomeBackgroundModule;
using Stelina.Domain.Models.DataContexts;
using Stelina.Domain.Models.Entities;
using Stelina.Domain.Models.ViewModels.ContactPostDetail;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Stelina.WebUI.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly StelinaDbContext db;
        private readonly CryptyoService cryptyoService;
        private readonly EmailService emailService;
        private readonly IMediator mediator;

        public HomeController(StelinaDbContext db, CryptyoService cryptyoService, EmailService emailService, IMediator mediator)
        {
            this.db = db;
            this.cryptyoService = cryptyoService;
            this.emailService = emailService;
            this.mediator = mediator;
        }

        public async Task<IActionResult> Index(HomeBackgroundGetAllQuery query)
        {
            var response = await mediator.Send(query);

            return View(response);
        }

        public async Task<IActionResult> AboutAsync()
        {
            var about = await db.AboutCompany.FirstOrDefaultAsync(cd => cd.DeletedDate == null);

            return View(about);
        }

        public IActionResult Faq()
        {
            var data = db.Faqs.Where(f => f.DeletedDate == null).ToList();
            return View(data);
        }

        public async Task<IActionResult> Contact()
        {
            var contactDetail = await db.ContactDetails.FirstOrDefaultAsync(cd => cd.DeletedDate == null);

            return View(new ContactPostDetailViewModel
            {
                ContactDetails = contactDetail
            });
        }

        [HttpPost]
        public async Task<IActionResult> Contact(ContactPostDetailViewModel vm)
        {
            if (ModelState.IsValid)
            {
                db.ContactPosts.Add(vm.ContactPosts);

                await db.SaveChangesAsync();

                var response = new
                {
                    error = false,
                    message = "Your request accepted, we will reply soon."
                };

                return Json(response);
            }

            var responseError = new
            {
                error = true,
                message = "Information is not correct, please try again",
                state = ModelState.GetError()
            };
            return Json(responseError);
        }

        [HttpPost]

        public async Task<IActionResult> Subscribe(Subscribe model)
        {

            if (model.Email == null)
            {
                return Json(new
                {
                    error = true,
                    message = "Email cannot be empty"
                });
            }

            if (!model.Email.IsEmail())
            {
                return Json(new
                {
                    error = true,
                    message = "Email is not avaiblable or correct, please try a valid one."
                });
            }

            if (!ModelState.IsValid)
            {
                string msg = ModelState.Values.First().Errors[0].ErrorMessage;

                return Json(new
                {
                    error = true,
                    message = msg
                });
            }

            var entity = db.Subscribes.FirstOrDefault(s => s.Email.Equals(model.Email));

            if (entity != null && entity.IsApproved == true)
            {
                return Json(new
                {
                    error = false,
                    message = "You have already subscribed"
                });
            }

            if (entity == null)
            {
                db.Subscribes.Add(model);
                db.SaveChanges();
            }
            else if (entity != null)
            {
                model.Id = entity.Id;
            }

            string token = $"{model.Id}-{model.Email}-{Guid.NewGuid()}";

            token = cryptyoService.Encrypt(token, true);


            string message = $"<p style='font-size: 16px;'>Please verify your subscription via this <a href='https://{Request.Host}/approve-subscribe?token={token}'>link</a></p>";

            await emailService.SendEmailAsync(model.Email, "Subscribe Approve Message", message);

            return Json(new
            {
                error = false,
                message = "We sent a confirmation message to your email. Please verify your subscription."
            });

        }

        [Route("/approve-subscribe")]
        public IActionResult SubscribeApprove(string token)
        {

            token = cryptyoService.Decrypt(token);

            Match match = Regex.Match(token, @"^(?<id>\d+)-(?<email>[^-]+)-(?<randomKey>.*)$");

            

            if (match.Success)
            {
                int id = Convert.ToInt32(match.Groups["id"].Value);
                string email = match.Groups["email"].Value;
                string randomKey = match.Groups["randomKey"].Value;

                var entity = db.Subscribes.FirstOrDefault(s => s.Id == id && s.DeletedDate == null);

                if (entity == null)
                {
                    ViewBag.Message = Tuple.Create(true, "Token error");
                    goto end;
                }

                if (entity.IsApproved)
                {
                    ViewBag.Message = Tuple.Create(true, "Your request already accepted"); 

                    goto end;
                }

                entity.IsApproved = true;
                entity.ApprovedDate = DateTime.UtcNow.AddHours(4);
                db.SaveChanges();


                ViewBag.Message = Tuple.Create(false, "Your subscription was confirmed");

            }
            else
            {
                ViewBag.Message = Tuple.Create(true, "Token error");
            }

        end:
            return View();
        }


    }
}
