namespace TeamSystem.Services.Matches.Models
{
    using System.ComponentModel.DataAnnotations;
    using TeamSystem.Common.Mapping;
    using TeamSystem.Entities;
    using static Data.DataConstants;

    public class TeamDetailsServiceModel : IMapFrom<Teams>
    {
        public int Id { get; set; }

        [Required]
        [MinLength(TeamNameMinLength)]
        [MaxLength(TeamNameMaxLength)]
        public string TeamName { get; set; }
    }
}
