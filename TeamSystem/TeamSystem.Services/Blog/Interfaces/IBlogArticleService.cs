namespace TeamSystem.Services.Blog.Interfaces
{
    using System.Threading.Tasks;
    using TeamSystem.Services.Blog.Models;

    public interface IBlogArticleService
    {
        Task CreateAsync(string title, string content, string thumbnailUrl, string authorId);

        Task EditAsync(int id, string title, string content, string thumbnailUrl);

        Task DeleteAsync(int id);

        Task<BlogArticleDetailsServiceModel> ById(int id);
    }
}
