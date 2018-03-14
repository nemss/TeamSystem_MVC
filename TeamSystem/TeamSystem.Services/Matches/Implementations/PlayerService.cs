namespace TeamSystem.Services.Matches.Implementations
{
    using System;
    using System.Threading.Tasks;
    using TeamSystem.Data;
    using TeamSystem.Entities;
    using TeamSystem.Services.Matches.Interfaces;

    public class PlayerService : IPlayerService
    {
        private readonly TeamSystemDbContext db;

        public PlayerService(TeamSystemDbContext db)
        {
            this.db = db;
        }

        public async Task CreateAsync(string firstName, string secondName, string LastName, string ucn, DateTime birthDate, int teamId, int modelId, bool isReserved)
        {
            var player = new PersonModels
            {
                FirstName = firstName,
                MiddleName = secondName,
                LastName = LastName,
                Ucn = ucn,
                BirthDate = birthDate,
                Team = await this.db.Teams.FindAsync(teamId),
                ModelRole = await this.db.ModelRoles.FindAsync(modelId),
                IsReserve = isReserved
            };

            await this.db.AddAsync(player);
            await this.db.SaveChangesAsync();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task EditAsync(string firstName, string secondName, string LastName, string ucn, DateTime birthDate, int teamId, int modelId, bool isReserved)
        {
            throw new NotImplementedException();
        }       

        public Task ByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
