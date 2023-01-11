using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Stelina.Domain.Models.DataContexts;
using Stelina.Domain.Models.Entities;

namespace Stelina.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactDetailsController : Controller
    {
        private readonly StelinaDbContext _context;

        public ContactDetailsController(StelinaDbContext context)
        {
            _context = context;
        }

        [Authorize(Policy = "admin.contactdetails.index")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.ContactDetails.ToListAsync());
        }

        [Authorize(Policy = "admin.contactdetails.details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactDetail = await _context.ContactDetails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contactDetail == null)
            {
                return NotFound();
            }

            return View(contactDetail);
        }

        [Authorize(Policy = "admin.contactdetails.create")]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "admin.contactdetails.create")]
        public async Task<IActionResult> Create([Bind("PhoneNumber,Location,SupportEmail,Id,CreatedDate,DeletedDate")] ContactDetail contactDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contactDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contactDetail);
        }

        [Authorize(Policy = "admin.contactdetails.edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactDetail = await _context.ContactDetails.FindAsync(id);
            if (contactDetail == null)
            {
                return NotFound();
            }
            return View(contactDetail);
        }
        

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "admin.contactdetails.edit")]
        public async Task<IActionResult> Edit(int id, [Bind("PhoneNumber,Location,SupportEmail,Id,CreatedDate,DeletedDate")] ContactDetail contactDetail)
        {
            if (id != contactDetail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contactDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactDetailExists(contactDetail.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(contactDetail);
        }

        [Authorize(Policy = "admin.contactdetails.delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactDetail = await _context.ContactDetails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contactDetail == null)
            {
                return NotFound();
            }

            return View(contactDetail);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "admin.contactdetails.delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contactDetail = await _context.ContactDetails.FindAsync(id);
            _context.ContactDetails.Remove(contactDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactDetailExists(int id)
        {
            return _context.ContactDetails.Any(e => e.Id == id);
        }
    }
}
