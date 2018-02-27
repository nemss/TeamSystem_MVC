namespace TeamSystem.Services.Admin.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Linq;
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

        public async Task<IEnumerable<AdminUserListingServiceModel>> AllAsync(int page = 1)
            => await this.db
                .Users
                .OrderBy(u => u.UserName)
                .Skip((page - 1) * ServiceConstants.UsersPageSize)
                .Take(ServiceConstants.UsersPageSize)
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

        public async Task<int> TotalAsync()
            => await this.db.Users.CountAsync();
    }
}
