using KonusarakOgren.Entities.Concrete;
using KonusarakOgren.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KonusarakOgren.WebUI.Controllers
{
    [Route("Role")]
    [Authorize(Roles = "SysAdmin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public RoleController(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        [HttpPost("RoleDelete")]
        public IActionResult RoleDelete(string id)
        {
            var role = _roleManager.FindByIdAsync(id).Result;
            if (role != null)
            {
                IdentityResult result = _roleManager.DeleteAsync(role).Result;
            }

            return RedirectToAction("Roles");
        }


        [HttpGet("RoleCreate")]
        public IActionResult RoleCreate()
        {
            return View();
        }

        [HttpPost("RoleCreate")]
        public IActionResult RoleCreate(RoleViewModel roleViewModel)
        {
            var role = new IdentityRole();
            role.Name = roleViewModel.Name;
            IdentityResult result = _roleManager.CreateAsync(role).Result;

            if (result.Succeeded)

            {
                return RedirectToAction("Roles");
            }
            else
            {
                return View(result);
            }
        }


        [HttpGet("Users")]
        public IActionResult Users()
        {
            return View(_userManager.Users.ToList());
        }

        [HttpPost("RoleAssign")]
        public IActionResult RoleAssign(string id)
        {
            TempData["userId"] = id;
            AppUser user = _userManager.FindByIdAsync(id).Result;

            ViewBag.userName = user.UserName;
            IQueryable<IdentityRole> roles = _roleManager.Roles;

            List<string> userroles = _userManager.GetRolesAsync(user).Result as List<string>;

            List<RoleAssignViewModel> roleAssignViewModels = new List<RoleAssignViewModel>();

            foreach (var role in roles)
            {
                RoleAssignViewModel r = new RoleAssignViewModel();
                r.RoleId = role.Id;
                r.RoleName = role.Name;
                if (userroles.Contains(role.Name))
                {
                    r.Exist = true;
                }
                else
                {
                    r.Exist = false;
                }
                roleAssignViewModels.Add(r);
            }

            return View(roleAssignViewModels);
        }

        [HttpPost("RoleAssign")]
        public async Task<IActionResult> RoleAssign(List<RoleAssignViewModel> roleAssignViewModels)
        {
            AppUser user = _userManager.FindByIdAsync(TempData["userId"].ToString()).Result;

            foreach (var item in roleAssignViewModels)
            {
                if (item.Exist)

                {
                    await _userManager.AddToRoleAsync(user, item.RoleName);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, item.RoleName);
                }
            }

            return RedirectToAction("Users");
        }
    }
}
