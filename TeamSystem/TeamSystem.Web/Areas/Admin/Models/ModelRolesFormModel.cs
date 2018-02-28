namespace TeamSystem.Web.Areas.Admin.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Data.DataConstants;

    public class ModelRolesFormModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Role Name")]
        [MinLength(ModelRolesNameMinLength)]
        [MaxLength(ModelRolesNameMaxLength)]
        public string RoleName { get; set; }
    }
}
