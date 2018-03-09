namespace TeamSystem.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using TeamSystem.Services.Matches.Interfaces;
    using TeamSystem.Web.Areas.Admin.Models;
    using TeamSystem.Web.Infrastructure.Extensions;
    using TeamSystem.Web.Infrastructure.Filters;

    public class TeamsController : BaseAdminController
    {
        private readonly ITeamService teams;

        public TeamsController(ITeamService teams)
        {
            this.teams = teams;
        }

        //GET: /admin/teams/create
        public IActionResult Create() => View();

        //POST: /admin/teams/create
        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Create(TeamsFormModel model)
        {
            await this.teams.CreateAsync(model.TeamName);

            return RedirectToAction(
                nameof(Web.Controllers.HomeController.Index),
                "News",
                new { area = string.Empty });
        }

        //GET: /admin/teams/edit{id}
        public async Task<IActionResult> Edit(int id)
        {
            var teamsFindById = await this.teams.ById(id);

            if (teamsFindById == null)
            {
                return NotFound();
            }
            
            return View(new TeamsFormModel
            {
                TeamName = teamsFindById.TeamName
            });
        }

        //POST: /admin/teams/edit{id}
        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Edit(TeamsFormModel model)
        {
            await this.teams.EditAsync(model.Id, model.TeamName);

            TempData.AddSuccessMessage($"Role {model.TeamName} successfully edited!");

            return RedirectToAction(
               nameof(Web.Controllers.NewsController.Index),
               "News",
               new { area = string.Empty });
        }

        //GET: admin/teams/delete{id}
        public async Task<IActionResult> Delete(int id)
        {
            var teamsFindById = await this.teams.ById(id);

            if (teamsFindById == null)
            {
                return NotFound();
            }

            return View(new ModelRolesFormModel
            {
                Id = teamsFindById.Id,
                RoleName = teamsFindById.TeamName,
            });
        }

        //POST: admin/teams/delete/{id}
        [HttpPost]
        public async Task<IActionResult> Destroy(int id)
        {
            var teamFindById = await this.teams.ById(id);

            if (teamFindById == null)
            {
                return NotFound();
            }

            await this.teams.DeleteAsync(id);

            TempData.AddSuccessMessage($"Article {teamFindById.TeamName} successfully deleted!");

            return RedirectToAction(
                nameof(Web.Controllers.NewsController.Index),
                "News",
                new { area = string.Empty });
        }
    }
}
