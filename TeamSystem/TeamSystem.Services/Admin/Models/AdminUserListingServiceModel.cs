﻿namespace TeamSystem.Services.Admin.Models
{
    using TeamSystem.Common.Mapping;
    using TeamSystem.Data.Models;

    public class AdminUserListingServiceModel : IMapFrom<User>
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }
    }
}
