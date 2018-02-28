namespace TeamSystem.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using TeamSystem.Services.Matches.Interfaces;
    using TeamSystem.Web.Areas.Admin.Models;
    using TeamSystem.Web.Infrastructure.Extensions;
    using TeamSystem.Web.Infrastructure.Filters;

    public class ModelRolesController : BaseAdminController
    {
        private readonly IRoleService roles;

        public ModelRolesController(IRoleService roles)
        {
            this.roles = roles;
        }

        //GET: /admin/modelroles/create
        public IActionResult Create() => View();

        //POST: /admin/modelroles/create
        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Create(ModelRolesFormModel model)
        {
            await this.roles.CreateAsync(model.RoleName);

            return RedirectToAction(
                nameof(Web.Controllers.HomeController.Index),
                "News",
                new { area = string.Empty });
        }


        //GET: /admin/modelroles/edit{id}
        public async Task<IActionResult> Edit(int id)
        {
            var roleFindById = await this.roles.ById(id);

            if (roleFindById == null)
            {
                return NotFound();
            }

            return View(new ModelRolesFormModel
            {
                RoleName = roleFindById.Role
            });
        }

        //POST: /admin/modelrolse/edit{id}
        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Edit(ModelRolesFormModel model)
        {
            await this.roles.EditAsync(model.Id, model.RoleName);

            TempData.AddSuccessMessage($"Role {model.RoleName} successfully edited!");

            return RedirectToAction(
               nameof(Web.Controllers.NewsController.Index),
               "News",
               new { area = string.Empty });
        }

        //GET: admin/modelrolse/delete{id}
        public async Task<IActionResult> Delete(int id)
        {
            var roleFindById = await this.roles.ById(id);

            if (roleFindById == null)
            {
                return NotFound();
            }

            return View(new ModelRolesFormModel
            {
                Id = roleFindById.Id,
                RoleName = roleFindById.Role,
            });
        }

        //POST: /blog/modelroles/delete/{id}
        [HttpPost]
        public async Task<IActionResult> Destroy(int id)
        {
            var roleFindById = await this.roles.ById(id);

            if (roleFindById == null)
            {
                return NotFound();
            }

            await this.roles.DeleteAsync(id);

            TempData.AddSuccessMessage($"Article {roleFindById.Role} successfully deleted!");

            return RedirectToAction(
                nameof(Web.Controllers.NewsController.Index),
                "News",
                new { area = string.Empty });
        }
    }
}
