namespace TeamSystem.Web.Areas.Admin.Models
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections.Generic;
    using TeamSystem.Data.Models;

    public class UserManageRoleForm
    {
        public string UserId { get; set; }

        public string Username { get; set; }

        public IEnumerable<SelectListItem> UserCurrentRoles { get; set; }

        public IEnumerable<SelectListItem> UserNewRoles { get; set; }
    }
}
