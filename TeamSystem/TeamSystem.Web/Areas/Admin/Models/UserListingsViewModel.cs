namespace TeamSystem.Web.Areas.Admin.Models
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections.Generic;
    using TeamSystem.Services.Admin.Models;

    public class UserListingsViewModel
    {
        public IEnumerable<AdminUserListingServiceModel> Users { get; set; }

        public IEnumerable<SelectListItem> Roles { get; set; }
    }
}
