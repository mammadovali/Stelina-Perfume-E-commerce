using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stelina.Domain.AppCode.Extensions;
using Stelina.Domain.Business.BasketModule;
using Stelina.Domain.Business.ProductModule;
using Stelina.Domain.Models.DataContexts;
using Stelina.Domain.Models.Entities;
using Stelina.Domain.Models.FormModel;
using Stelina.Domain.Models.ViewModels.ProductViewModel;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Stelina.WebUI.Controllers
{
    [AllowAnonymous]
    public class ShopController : Controller
    {
        private readonly StelinaDbContext db;
        private readonly IMediator mediator;

        public ShopController(StelinaDbContext db, IMediator mediator)
        {
            this.db = db;
            this.mediator = mediator;
        }
        public async Task<IActionResult> Index(string sortOrder)
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

            //ViewBag.NameSort = String.IsNullOrWhiteSpace(sortOrder) ? "nameDesc" : "";
            //ViewBag.PriceSort = sortOrder == "Price" ? "sortDesc" : "price";

            

            //switch (sortOrder)
            //{
            //    case "nameDesc":
            //        products = products.OrderByDescending(p => p.Name);
            //        break;
            //    case "price":
            //        products = products.OrderBy(p => p.Price);
            //        break;
            //    case "priceDescending":
            //        products = products.OrderByDescending(p => p.Price);
            //        break;
            //    default:
            //        products = products.OrderBy(p => p.Name);
            //        break;
            //}

            return View(vm);
        }

        [HttpPost]
        public IActionResult Filter(ShopFilterFormModel model)
        {
            var query = db.Products
                .Include(p => p.Images.Where(i => i.IsMain == true))
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .Where(p => p.DeletedDate == null)
                .AsQueryable();

            if (model?.Brands?.Count() > 0)
            {
                 query = query.Where(p => model.Brands.Contains(p.BrandId));
            }

            if (model?.Categories?.Count() > 0)
            {
                 query = query.Where(p => model.Categories.Contains(p.CategoryId));
            }

            if (model.Prices[0] >= 0 && model.Prices[0] <= model.Prices[1])
            {
                query = query.Where(q => q.Price >= model.Prices[0] && q.Price <= model.Prices[1]);
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

        public async Task<IActionResult> Wishlist(WishlistQuery query)
        {
            var favs = await mediator.Send(query);

            if (Request.IsAjaxRequest())
            {
                return PartialView("_WishlistBody", favs);
            }

            return View(favs);
        }

        [Route("/basket")]
        [Authorize(Policy = "shop.basket")]
        public IActionResult Basket()
        {
            return View();
        }

        [HttpPost]
        [Route("/basket")]
        [Authorize(Policy = "shop.basket")]
        public async Task<IActionResult> Basket(AddToBasketCommand command)
        {
            var response = await mediator.Send(command);

            return Json(response);
        }
    }
}
