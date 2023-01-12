using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stelina.Domain.Models.DataContexts;
using System.Threading.Tasks;
using System.Linq;
using System;
using Stelina.Domain.AppCode.Extensions;
using Stelina.Domain.Models.ViewModels.UserRole;

namespace Stelina.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        private readonly StelinaDbContext db;

        public UsersController(StelinaDbContext db)
        {
            this.db = db;
        }



        [Authorize(Policy = "admin.users.index")]
        public async Task<IActionResult> Index()
        {
            var data = await db.Users.ToListAsync();

            return View(data);
        }

        [Authorize(Policy = "admin.users.details")]
        public async Task<IActionResult> Details(int id) // int roleId = 1
        {
            var user = await db.Users
                .FirstOrDefaultAsync(u => u.Id == id);

            //var role = await db.Roles
            //    .FirstOrDefaultAsync(r => r.Id == roleId);

            //var data = new UserRoleViewModel
            //{
            //   User = user,
            //   Role = role
            //};

            if (user == null)
            {
                return NotFound();
            }

            ViewBag.Roles = await (from r in db.Roles
                                   join ur in db.UserRoles
                                   on new { RoleId = r.Id, UserId = user.Id } equals new { ur.RoleId, ur.UserId } into lJoin
                                   from lj in lJoin.DefaultIfEmpty()
                                   select Tuple.Create(r.Id, r.Name, lj != null)).ToListAsync();


            ViewBag.Principals = (from p in Extension.policies
                                  join uc in db.UserClaims on new { ClaimValue = "1", ClaimType = p, UserId = user.Id } equals new { uc.ClaimValue, uc.ClaimType, uc.UserId } into lJoin
                                  from lj in lJoin.DefaultIfEmpty()
                                  select Tuple.Create(p, lj != null)).ToList();

            //ViewBag.Allprincipals = (from p in Extension.policies
            //                         join uc in db.UserClaims on new { ClaimValue = "1", ClaimType = p, UserId = user.Id } equals new { uc.ClaimValue, uc.ClaimType, uc.UserId } into lJoin
            //                         from lj in lJoin.DefaultIfEmpty()
            //                         select Tuple.Create(p, lj != null))

            //                         .Union(
            //    (from p in Extension.policies
            //     join rc in db.RoleClaims on new { ClaimValue = "1", ClaimType = p, RoleId = role.Id } equals new { rc.ClaimValue, rc.ClaimType, rc.RoleId } into lJoin
            //     from lj in lJoin.DefaultIfEmpty()
            //     select Tuple.Create(p, lj != null))
            //                          )

            //                         .ToList();

            return View(user);
        }
    }
}








