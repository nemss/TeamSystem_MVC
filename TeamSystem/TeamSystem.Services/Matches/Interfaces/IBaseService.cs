namespace TeamSystem.Services.Matches.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IBaseService<T>
    {
        Task CreateAsync(string name);

        Task EditAsync(int id, string name);

        Task DeleteAsync(int id);

        Task<IEnumerable<T>> AllAsync();

        Task<T> ById(int id);
    }
}
