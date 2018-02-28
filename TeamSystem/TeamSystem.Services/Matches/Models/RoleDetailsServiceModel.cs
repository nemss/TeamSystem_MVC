namespace TeamSystem.Services.Matches.Models
{
    using System.ComponentModel.DataAnnotations;
    using TeamSystem.Common.Mapping;
    using TeamSystem.Data.Models;
    using static Data.DataConstants;

    public class RoleDetailsServiceModel : IMapFrom<ModelRoles>
    {
        public int Id { get; set; }

        [MinLength(ModelRolesNameMinLength)]
        [MaxLength(ModelRolesNameMaxLength)]
        public string Role { get; set; }
    }
}
