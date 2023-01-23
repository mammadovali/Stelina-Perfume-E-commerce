using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stelina.Domain.Models.DataContexts;
using System.Linq;
using System.Threading.Tasks;

namespace Stelina.Domain.Models.ViewComponents.Categories
{
    public class CategoriesViewComponent : ViewComponent
    {
        private readonly StelinaDbContext db;

        public CategoriesViewComponent(StelinaDbContext db)
        {
            this.db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var entity = await db.Categories
                .Where(c => c.DeletedDate == null && c.ParentId == null)
                .Include(c => c.Children)
                .ThenInclude(c => c.Children).Where(ch => ch.DeletedDate == null).ToListAsync();

            return View(entity);
        }
    }
}
