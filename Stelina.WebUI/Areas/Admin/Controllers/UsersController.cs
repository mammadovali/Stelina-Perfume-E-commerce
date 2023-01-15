using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stelina.Domain.Models.DataContexts;
using System.Threading.Tasks;
using System.Linq;
using System;
using Stelina.Domain.AppCode.Extensions;
using Stelina.Domain.Models.ViewModels.UserRole;
using Stelina.Domain.Models.Entities.Membership;

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


        [HttpPost]
        [Route("/user-set-role")]
        [Authorize(Policy = "admin.users.setrole")]
        public async Task<IActionResult> SetRole(int userId, int roleId, bool selected)
        {
            #region Check user and role

            var user = await db.Users.FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
            {
                return Json(new
                {
                    error = true,
                    message = "Xətalı sorğu"
                });
            }

            if (userId == User.GetCurrentUserId())
            {
                return Json(new
                {
                    error = true,
                    message = "İstifadəçi özünə rol verə bilməz"
                });
            }


            var role = await db.Roles.FirstOrDefaultAsync(r => r.Id == roleId);

            if (role == null)
            {
                return Json(new
                {
                    error = true,
                    message = "Xətalı sorğu"
                });
            }

            #endregion

            if (selected)
            {
                if (await db.UserRoles.AnyAsync(ur => ur.UserId == userId && ur.RoleId == roleId))
                {
                    return Json(new
                    {
                        error = true,
                        message = $"{user.Name} {user.Surname} adlı istifadəçi {role.Name} adlı roldadır"
                    });
                }
                else
                {
                    db.UserRoles.Add(new StelinaUserRole
                    {
                        UserId = userId,
                        RoleId = roleId
                    });

                    await db.SaveChangesAsync();

                    return Json(new
                    {
                        error = false,
                        message = $"{user.Name} {user.Surname} adlı istifadəçiyə {role.Name} adlı rol verildi"
                    });
                }
            }
            else
            {
                var userRole = await db.UserRoles.FirstOrDefaultAsync(ur => ur.UserId == userId && ur.RoleId == roleId);

                if (userRole == null)
                {
                    return Json(new
                    {
                        error = true,
                        message = $"{user.Name} {user.Surname} adlı istifadəçi {role.Name} adlı rolda deyil!"
                    });
                }
                else
                {
                    db.UserRoles.Remove(userRole);

                    await db.SaveChangesAsync();

                    return Json(new
                    {
                        error = false,
                        message = $"{user.Name} {user.Surname} adlı istifadəçi {role.Name} adlı roldan çıxarıldı!"
                    });

                }
            }

        }

        [HttpPost]
        [Route("/user-set-principal")]
        [Authorize(Policy = "admin.users.setprincipal")]
        public async Task<IActionResult> SetPrincipal(int userId, string principalName, bool selected)
        {
            var user = await db.Users.FirstOrDefaultAsync(u => u.Id == userId);


            #region Check user and principal

            if (user == null)
            {
                return Json(new
                {
                    error = true,
                    message = "Xətalı sorğu"
                });
            }

            if (userId == User.GetCurrentUserId())
            {
                return Json(new
                {
                    error = true,
                    message = "İstifadəçi özünə səlahiyyət verə bilməz"
                });
            }

            var hasPrincipal = Extension.policies.Contains(principalName);


            if (!hasPrincipal)
            {
                return Json(new
                {
                    error = true,
                    message = "Xətalı sorğu"
                });
            }

            #endregion

            if (selected)
            {
                if (await db.UserClaims.AnyAsync(uc => uc.UserId == userId && uc.ClaimType.Equals(principalName) && uc.ClaimValue.Equals("1") ))
                {
                    return Json(new
                    {
                        error = true,
                        message = $"{user.Name} {user.Surname} adlı istifadəçi {principalName} adlı səlahiyyətə malikdir"
                    });
                }
                else
                {
                    db.UserClaims.Add(new StelinaUserClaim
                    {
                        UserId = userId,
                        ClaimType = principalName,
                        ClaimValue = "1"
                    });

                    await db.SaveChangesAsync();

                    return Json(new
                    {
                        error = false,
                        message = $"{user.Name} {user.Surname} adlı istifadəçiyə {principalName} adlı səlahiyyət verildi"
                    });
                }

            }
            else
            {
                var userClaim = await db.UserClaims.FirstOrDefaultAsync(uc => uc.UserId == userId && uc.ClaimType.Equals(principalName) && uc.ClaimValue.Equals("1"));

                if (userClaim == null)
                {
                    return Json(new
                    {
                        error = true,
                        message = $"{user.Name} {user.Surname} adlı istifadəçi {principalName} adlı səlahiyyətə malik deyil!"
                    });
                }
                else
                {
                    db.UserClaims.Remove(userClaim);

                    await db.SaveChangesAsync();

                    return Json(new
                    {
                        error = false,
                        message = $"{user.Name} {user.Surname} adlı istifadəçidən {principalName} adlı səlahiyyət qaldırıldı"
                    });
                }
            }
        }



    }
}








