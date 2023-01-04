using MediatR;
using Microsoft.AspNetCore.Mvc;
using Stelina.Domain.AppCode.Extensions;
using Stelina.Domain.Models.DataContexts;
using Stelina.Domain.Models.ViewModels.ContactPostDetail;
using System.Linq;
using System.Threading.Tasks;

namespace Stelina.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly StelinaDbContext db;

        public HomeController(StelinaDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Faq()
        {
            var data = db.Faqs.Where(f => f.DeletedDate == null).ToList();
            return View(data);
        }

        public IActionResult Contact()
        {
            var contactDetail = db.ContactDetails.FirstOrDefault();

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


    }
}
