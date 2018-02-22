using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TeamSystem.Data.Models;
using TeamSystem.Services.Article.Interfaces;
using TeamSystem.Web.Models.Articles;

namespace TeamSystem.Web.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly IArticleService articles;
        private readonly UserManager<User> userManager;

        public ArticlesController(IArticleService articles,
                                  UserManager<User> userManager)
        {
            this.articles = articles;
            this.userManager = userManager;
        }

        //GET: /articles/
        public async Task<IActionResult> Index(int page = 1)
            => View(new ArticleListingViewModel
            {
                Articles = await this.articles.AllAsync(page),
                TotalArticles = await this.articles.TotalAsync(),
                CurrentPage = page
            });
    }
}
