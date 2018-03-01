namespace TeamSystem.Web.Areas.Admin.Models
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections.Generic;
    using TeamSystem.Data.Models;

    public class UserManageRoleForm
    {
        public string UserId { get; set; }

        public string Username { get; set; }

        public IEnumerable<string> UserCurrentRoles { get; set; }

        public IEnumerable<string> UserNewRoles { get; set; }

        public IEnumerable<string> Roles { get; set; }
    }
}
