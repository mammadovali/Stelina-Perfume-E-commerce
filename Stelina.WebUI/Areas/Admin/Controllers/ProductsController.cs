using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Stelina.Domain.Models.DataContexts;
using Stelina.Domain.Business.ProductModule;

namespace Stelina.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly StelinaDbContext db;
        private readonly IMediator mediator;

        public ProductsController(StelinaDbContext db, IMediator mediator)
        {
            this.db = db;
            this.mediator = mediator;
        }

        [Authorize(Policy = "admin.products.index")]
        public async Task<IActionResult> Index(ProductsPagedQuery query)
        {
            var response = await mediator.Send(query);

            return View(response);
        }



        [Authorize(Policy = "admin.products.details")]
        public async Task<IActionResult> Details(ProductSingleQuery query)
        {
            var response = await mediator.Send(query);

            return View(response);
        }


        [Authorize(Policy = "admin.products.create")]
        public IActionResult Create()
        {
            ViewData["BrandId"] = new SelectList(db.Brands, "Id", "Name");
            ViewData["CategoryId"] = new SelectList(db.Categories, "Id", "Name");

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "admin.products.create")]
        public async Task<IActionResult> Create(ProductCreateCommand command)
        {
            if (command.Images == null)
            {
                ModelState.AddModelError("ImagePath", "Product image should not be left empty");
            }

            if (ModelState.IsValid)
            {
                var response = await mediator.Send(command);

                return RedirectToAction(nameof(Index));
            }


            ViewBag.BrandId = new SelectList(db.Brands, "Id", "Name", command.BrandId);
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", command.CategoryId);
            return View(command);

        }

        [Authorize(Policy = "admin.products.edit")]
        public async Task<IActionResult> Edit(ProductSingleQuery query)
        {
            var product = await mediator.Send(query);

            if (product == null)
            {
                return NotFound();
            }

            var command = new ProductEditCommand();
            command.Name = product.Name;
            command.Price = product.Price;
            command.Description = product.Description;
            command.BrandId = product.BrandId;
            command.CategoryId = product.CategoryId;
            command.StockKeepingUnit = product.StockKeepingUnit;

            command.Images = product.Images.Select(x => new ImageItem
            {
                Id = x.Id,
                TempPath = x.Name,
                IsMain = x.IsMain,


            }).ToArray();

            ViewData["BrandId"] = new SelectList(db.Brands, "Id", "Name", product.BrandId);
            ViewData["CategoryId"] = new SelectList(db.Categories, "Id", "Name", product.CategoryId);
            return View(command);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "admin.products.edit")]
        public async Task<IActionResult> Edit(ProductEditCommand command)
        {
            if (ModelState.IsValid)
            {
                var response = await mediator.Send(command);

                ViewData["BrandId"] = new SelectList(db.Brands, "Id", "Name", command.BrandId);
                ViewData["CategoryId"] = new SelectList(db.Categories, "Id", "Name", command.CategoryId);

                return RedirectToAction(nameof(Index));
            }

            ViewData["BrandId"] = new SelectList(db.Brands, "Id", "Name", command.BrandId);
            ViewData["CategoryId"] = new SelectList(db.Categories, "Id", "Name", command.CategoryId);
            return View(command);
            
        }



        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "admin.products.delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await db.Products.FirstOrDefaultAsync(p => p.Id == id && p.DeletedDate == null);

            if (product == null)
            {
                return Json(new
                {
                    error = true,
                    message = "Melumat movcud deyil"
                });
            }

            product.DeletedDate = DateTime.UtcNow.AddHours(4);
            await db.SaveChangesAsync();

            var response = await mediator.Send(new ProductsPagedQuery());

            return PartialView("_ListBody", response);


        }



        private bool ProductExists(int id)
        {
            return db.Products.Any(e => e.Id == id);
        }
    }
}