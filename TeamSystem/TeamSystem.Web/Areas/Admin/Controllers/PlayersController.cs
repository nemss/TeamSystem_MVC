namespace TeamSystem.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using TeamSystem.Services.Matches.Interfaces;
    using TeamSystem.Web.Areas.Admin.Models;

    public class PlayersController : BaseAdminController
    {
        private readonly IPlayerService players;
        private readonly ITeamService teams;
        private readonly IRoleService roles;

        public PlayersController(IPlayerService players,
                                 ITeamService teams,
                                 IRoleService roles)
        {
            this.players = players;
            this.teams = teams;
            this.roles = roles;
        }

        //GET: /admin/players/create 
        public async Task<IActionResult> Create()
        {
            var teams = await this.teams.AllAsync();
            var modelRoles = await this.roles.AllAsync();

            var teamsSelectListItem = teams
                 .Select(t => new SelectListItem
                 {
                     Text = t.TeamName,
                     Value = t.TeamName
                 });

            var modelRolesSelectListItem = modelRoles
                .Select(md => new SelectListItem
                {
                    Text = md.Role,
                    Value = md.Role
                });

            return View(new PlayerFormModel
            {
                Teams = teamsSelectListItem,
                ModelRoles = modelRolesSelectListItem
            });
        }

        //POST: /admin/players/create
        //public async Task<IActionResult> Create()
        //{

        //}
    }
}
