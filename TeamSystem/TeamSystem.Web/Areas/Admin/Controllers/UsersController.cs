namespace TeamSystem.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using System.Threading.Tasks;
    using TeamSystem.Data.Models;
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

        //POST: /admin/users/AddToRole
        [HttpPost]
        public async Task<IActionResult> AddToRole(AddUserToRoleFormModel model)
        {
            var roleExists = await this.roleManager.RoleExistsAsync(model.Role);
            var user = await this.userManager.FindByIdAsync(model.UserId);
            var userRoles = await this.userManager.GetRolesAsync(user);
            var userExists = user != null;

            if (!roleExists || !userExists)
            {
                ModelState.AddModelError(string.Empty, "Invalid identity details !");
            }

            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }

            if(userRoles.Contains(model.Role))
            {
                TempData.AddErrorMessage($"User {user.UserName} is already added to the {model.Role} role !");
                return RedirectToAction(nameof(Index));
            }

            await this.userManager.AddToRoleAsync(user, model.Role);

            TempData.AddSuccessMessage($"User {user.UserName} successfully added to the {model.Role} role !");
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

        [HttpPost]
        public async Task<IActionResult> RemoveRole(RemoveUserToRoleFormModel model)
        {
            var user = await this.userManager.FindByIdAsync(model.UserId);
            var userRoles = await this.userManager.GetRolesAsync(user);

            if(!userRoles.Contains(model.Role))
            {
                TempData.AddErrorMessage($"No such role found for user {user.UserName} !");
                return RedirectToAction(nameof(Index));
            }

            await this.userManager.RemoveFromRoleAsync(user, model.Role);

            TempData.AddSuccessMessage($"Successfuly removed role {model.Role} from user {user.UserName} !");
            return RedirectToAction(nameof(Index));
        }
    }
}
