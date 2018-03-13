namespace TeamSystem.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using TeamSystem.Services.Matches.Interfaces;

    public class PlayersController : BaseAdminController
    {
        private readonly IPlayerService players;

        public PlayersController(IPlayerService players)
        {
            this.players = players;
        }

        //GET: /admin/players/create 
        public IActionResult Create() => View();

        //POST: /admin/players/create
        //public Task<IActionResult> Create()
        //{

        //}
    }
}
