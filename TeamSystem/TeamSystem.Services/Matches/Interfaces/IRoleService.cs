namespace TeamSystem.Services.Matches.Interfaces
{
    using System.Threading.Tasks;
    using TeamSystem.Services.Matches.Models;

    public interface IRoleService
    {
        Task CreateAsync(string roleName);

        Task EditAsync(int id, string roleName);

        Task DeleteAsync(int id);

        Task<RoleDetailsServiceModel> ById(int id);
    }
}
