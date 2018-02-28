namespace TeamSystem.Web.Areas.Admin.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public abstract class RoleFormModel
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        public IEnumerable<string> Roles { get; set; }
    }
}