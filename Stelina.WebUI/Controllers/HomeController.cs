using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stelina.Domain.AppCode.Extensions;
using Stelina.Domain.AppCode.Services;
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

        public HomeController(StelinaDbContext db, CryptyoService cryptyoService, EmailService emailService)
        {
            this.db = db;
            this.cryptyoService = cryptyoService;
            this.emailService = emailService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Faq()
        {
            var data = db.Faqs.Where(f => f.DeletedDate == null).ToList();
            return View(data);
        }

        public async Task<IActionResult> Contact()
        {
            var contactDetail = await db.ContactDetails.FirstOrDefaultAsync();

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
                    message = "Müraciətiniz qeydə alındı, tezliklə geri dönüş edəcəyik"
                };

                return Json(response);
            }

            var responseError = new
            {
                error = true,
                message = "Məlumatlar uyğun deyil, zəhmət olmasa yənidən yoxlayın",
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
                    message = "Boş göndərilə bilməz"
                });
            }

            if (!model.Email.IsEmail())
            {
                return Json(new
                {
                    error = true,
                    message = "Məlumat düzgün göndərilməyib"
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
                    message = "Siz artıq abunə olmusunuz"
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


            string message = $"Zəhmət olmasa <a href='https://{Request.Host}/approve-subscribe?token={token}'>link</a> vasitəsilə abunəliyinizi təsdiq edin";


            await emailService.SendEmailAsync(model.Email, "Subscribe Approve Message", message);

            return Json(new
            {
                error = false,
                message = "E-mailinizə təsdiq mesajı göndərildi"
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
                    ViewBag.Message = Tuple.Create(true, "Token xətası");
                    goto end;
                }

                if (entity.IsApproved)
                {
                    ViewBag.Message = Tuple.Create(true, "Sizin müraciətiniz artıq təsdiq edilib"); 

                    goto end;
                }

                entity.IsApproved = true;
                entity.ApprovedDate = DateTime.UtcNow.AddHours(4);
                db.SaveChanges();


                ViewBag.Message = Tuple.Create(false, "Sizin abunəliyiniz təsdiq edildi");

            }
            else
            {
                ViewBag.Message = Tuple.Create(true, "Token xətası");
            }

        end:
            return View();


        }


    }
}
