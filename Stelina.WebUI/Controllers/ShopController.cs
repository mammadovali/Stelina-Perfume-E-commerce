using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stelina.Domain.Models.DataContexts;
using Stelina.Domain.Models.FormModel;
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
                .ThenInclude(c => c.Children)
                .Where(c => c.DeletedDate == null && c.ParentId == null).ToListAsync();

            var products = await db.Products
                .Include(p => p.Images.Where(i => i.IsMain == true))
                .Where(p => p.DeletedDate == null).ToListAsync();

            var vm = new ProductViewModel()
            {
                Brands = brands,
                Categories = categories,
                Products = products
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult Filter(ShopFilterFormModel model)
        {
            var query = db.Products
                .Include(p => p.Images.Where(i => i.IsMain == true))
                .Include(p => p.Brand)
                .Where(p => p.DeletedDate == null)
                .AsQueryable();

            if (model?.Brands?.Count() > 0)
            {
                 query = query.Where(p => model.Brands.Contains(p.BrandId));
            }

            return PartialView("_ProductContainer", query.ToList());

            //return Json(new
            //{
            //    error = false,
            //    data = query.ToList()
            //});
        }

        public async Task<IActionResult> Details(int id)
        {
            var entity = await db.Products
                .Include(p => p.Images)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (entity == null)
            {
                return NotFound();
            }

            return View(entity);
        }
    }
}
