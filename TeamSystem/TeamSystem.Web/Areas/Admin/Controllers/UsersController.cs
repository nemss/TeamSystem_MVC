namespace TeamSystem.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using TeamSystem.Entities;
    using TeamSystem.Services.Admin.Interfaces;
    using TeamSystem.Web.Areas.Admin.Models;
    using TeamSystem.Web.Infrastructure.Extensions;

    public class UsersController : BaseAdminController
    {
        private readonly IAdminUserService users;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public UsersController(IAdminUserService users,
                               UserManager<User> userManager,
                               RoleManager<IdentityRole> roleManager)
        {
            this.users = users;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        //GET: /admin/users/
        public async Task<IActionResult> Index(int page = 1)
        {
            var users = await this.users.AllAsync(page);
            var roles = await this.roleManager
                .Roles
                .Select(r => new SelectListItem
                {
                    Text = r.Name,
                    Value = r.Name
                })
                .ToListAsync();

            return View(new UserListingsViewModel
            {
                Users = users,
                Roles = roles,
                TotalUsers = await this.users.TotalAsync(),
                CurrentPage = page
            });
        }

        //GET: /admin/users/ManageRole
        public async Task<IActionResult> ManageRole(string userId)
        {
            var user = await this.userManager.FindByIdAsync(userId);
            var userRoles = await this.userManager.GetRolesAsync(user);
            var roles = await this.roleManager.Roles.Select(r => r.Name).ToListAsync();

            return View(new UserManageRoleForm
            {
                UserId = userId,
                Username = user.UserName,
                UserCurrentRoles = userRoles.ToList(),
                Roles = roles
            });
        }

        //POST: /admin/users/ManageRole
        [HttpPost]
        public async Task<IActionResult> Manage(UserManageRoleForm model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }

            var user = await this.userManager.FindByIdAsync(model.UserId);
            var userRoles = await this.userManager.GetRolesAsync(user);
            var roles = await this.roleManager.Roles.Select(r => r.Name).ToListAsync();

            if(model.UserNewRoles is null)
            {
                model.UserNewRoles = new List<string>();
            }

            foreach (var role in roles)
            {
                if (model.UserNewRoles.Contains(role) && !userRoles.Contains(role))
                {
                    await this.userManager.AddToRoleAsync(user, role);
                }
                else if (!model.UserNewRoles.Contains(role) && userRoles.Contains(role))
                {
                    await this.userManager.RemoveFromRoleAsync(user, role);
                }
            }
            TempData.AddSuccessMessage($"Successfuly made changes to roles on user - {user.UserName}");

            return RedirectToAction(nameof(Index));
        }

        //GET: /Admin/Users/DeleteUser/{id}
        public async Task<IActionResult> DeleteUser(string userId)
        {
            var findUser = await this.userManager.FindByIdAsync(userId);

            if (findUser == null)
            {
                return NotFound();
            }

            return View(new UserDeleteForm
            {
                Id = findUser.Id,
                Username = findUser.UserName,
                Email = findUser.Email
            });
        }

        //POST: /Admin/Users/DeleteUser/{id}
        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            var findUserById = await this.userManager.FindByIdAsync(id);

            if (findUserById == null)
            {
                return NotFound();
            }

            await this.users.DeleteAsync(findUserById.Id);

            TempData.AddSuccessMessage($"User {findUserById.UserName} successfully deleted !");

            return RedirectToAction(nameof(Index));
        }
    }
}
