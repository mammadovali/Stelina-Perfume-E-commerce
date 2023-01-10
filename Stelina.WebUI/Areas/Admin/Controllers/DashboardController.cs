using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Stelina.WebUI.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        [Area("Admin")]
        [Authorize(Roles = "sa")]

        public IActionResult Index()
        {
            return View();
        }
    }
}
