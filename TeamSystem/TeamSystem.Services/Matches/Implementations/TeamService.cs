namespace TeamSystem.Services.Matches.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using System.Threading.Tasks;
    using TeamSystem.Data;
    using TeamSystem.Entities;
    using TeamSystem.Services.Matches.Interfaces;
    using TeamSystem.Services.Matches.Models;

    public class TeamService : ITeamService
    {
        private readonly TeamSystemDbContext db;

        public TeamService(TeamSystemDbContext db)
        {
            this.db = db;
        }

        public async Task CreateAsync(string name)
        {
            var team = new Teams
            {
                TeamName = name
            };

            await this.db.AddAsync(team);
            await this.db.SaveChangesAsync();
        }

        public async Task EditAsync(int id, string name)
        {
            var teamById = await this.db.Teams.FindAsync(id);

            if (teamById == null)
            {
                return;
            }

            teamById.TeamName = name;

            await this.db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var teamById = await this.db.Teams.FindAsync(id);

            if (teamById == null)
            {
                return;
            }

            this.db.Remove(teamById);
            await this.db.SaveChangesAsync();
        }

       public async Task<TeamDetailsServiceModel> ById(int id)
            => await this.db
                           .Teams
                           .Where(a => a.Id == id)
                           .ProjectTo<TeamDetailsServiceModel>()
                           .FirstOrDefaultAsync();
    }
}
