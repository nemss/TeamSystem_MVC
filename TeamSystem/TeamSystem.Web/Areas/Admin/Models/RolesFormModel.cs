namespace TeamSystem.Web.Areas.Admin.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class RolesFormModel
    {
        [Required]
        public string UserId { get; set; }

        public IEnumerable<string> Roles { get; set; }
    }
}