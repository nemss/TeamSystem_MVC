namespace TeamSystem.Services.Matches.Interfaces
{
    using System.Threading.Tasks;

    public interface IBaseService<T>
    {
        Task CreateAsync(string name);

        Task EditAsync(int id, string name);

        Task DeleteAsync(int id);

        Task<T> ById(int id);
    }
}
