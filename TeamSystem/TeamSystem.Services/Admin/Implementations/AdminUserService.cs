namespace TeamSystem.Services.Admin.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TeamSystem.Data;
    using TeamSystem.Services.Admin.Interfaces;
    using TeamSystem.Services.Admin.Models;

    public class AdminUserService : IAdminUserService
    {
        private readonly TeamSystemDbContext db;

        public AdminUserService(TeamSystemDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<AdminUserListingServiceModel>> AllAsync()
            => await this.db
            .Users
            .ProjectTo<AdminUserListingServiceModel>()
            .ToListAsync();


        public async Task DeleteAsync(string userId)
        {
            var findUserById = await this.db.Users.FindAsync(userId);

            if (findUserById == null)
            {
                return;
            }

            this.db.Users.Remove(findUserById);
            await this.db.SaveChangesAsync();
        }
    }
}
