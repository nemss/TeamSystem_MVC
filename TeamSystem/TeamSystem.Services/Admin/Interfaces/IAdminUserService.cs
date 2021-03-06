﻿namespace TeamSystem.Services.Admin.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TeamSystem.Services.Admin.Models;

    public interface IAdminUserService
    {
        Task<IEnumerable<AdminUserListingServiceModel>> AllAsync(int page = 1);

        Task DeleteAsync(string userId);

        Task<int> TotalAsync();
    }
}
