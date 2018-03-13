namespace TeamSystem.Services.Matches.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using TeamSystem.Data;
    using TeamSystem.Entities;
    using TeamSystem.Services.Matches.Interfaces;
    using TeamSystem.Services.Matches.Models;

    public class RoleService : IRoleService
    {
        private readonly TeamSystemDbContext db;

        public RoleService(TeamSystemDbContext db)
        {
            this.db = db;
        }

        public async Task CreateAsync(string roleName)
        {
            var role = new ModelRoles
            {
                Role = roleName
            };

            await this.db.AddAsync(role);
            await this.db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var roleById = await this.db.ModelRoles.FindAsync(id);

            if(roleById == null)
            {
                return;
            }

            this.db.Remove(roleById);
            await this.db.SaveChangesAsync();
        }

        public async Task EditAsync(int id, string roleName)    
        {
            var roleById = await this.db.ModelRoles.FindAsync(id);

            if(roleById == null)
            {
                return;
            }

            roleById.Role = roleName;

            await this.db.SaveChangesAsync();
        }

        public async Task<RoleDetailsServiceModel> ById(int id)
            => await this.db
                           .ModelRoles
                           .Where(a => a.Id == id)
                           .ProjectTo<RoleDetailsServiceModel>()
                           .FirstOrDefaultAsync();

        public async Task<IEnumerable<RoleDetailsServiceModel>> AllAsync()
            => await this.db
                         .ModelRoles
                         .ProjectTo<RoleDetailsServiceModel>()
                         .ToListAsync();
    }
}
