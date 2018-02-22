namespace TeamSystem.Services.Article.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TeamSystem.Services.Article.Models;

    public interface IArticleService
    {
        Task<IEnumerable<ArticlesListingServiceModel>> AllAsync(int page = 1);

        Task<int> TotalAsync();

        Task<IEnumerable<ArticlesListingServiceModel>> FindAsync(string searchText);

        Task<ArticlesListingServiceModel> ById(int id);
    }
}
