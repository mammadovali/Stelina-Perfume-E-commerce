using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stelina.Domain.Models.DataContexts;
using Stelina.Domain.Models.ViewModels.ProductViewModel;
using System.Linq;
using System.Threading.Tasks;

namespace Stelina.WebUI.Controllers
{
    [AllowAnonymous]
    public class ShopController : Controller
    {
        private readonly StelinaDbContext db;

        public ShopController(StelinaDbContext db)
        {
            this.db = db;
        }
        public async Task<IActionResult> Index()
        {
            var brands = await db.Brands.Where(b => b.DeletedDate == null).ToListAsync();
            var categories = await db.Categories
                .Include(c => c.Children)
                .ThenInclude(c => c.Children)
                .ThenInclude(c => c.Children)
                .Where(c => c.DeletedDate == null && c.ParentId == null).ToListAsync();

            var vm = new ProductViewModel()
            {
                Brands = brands,
                Categories = categories
            };

            return View(vm);
        }

        public IActionResult Details()
        {
            return View();
        }
    }
}
