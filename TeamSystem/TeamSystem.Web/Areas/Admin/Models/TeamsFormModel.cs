namespace TeamSystem.Web.Areas.Admin.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Data.DataConstants;

    public class TeamsFormModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Team Name")]
        [MinLength(TeamNameMinLength)]
        [MaxLength(TeamNameMaxLength)]
        public string TeamName { get; set; }
    }
}
