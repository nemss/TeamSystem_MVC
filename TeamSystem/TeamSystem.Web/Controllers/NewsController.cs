namespace TeamSystem.Web.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using TeamSystem.Data.Models;
    using TeamSystem.Services.Article.Interfaces;
    using TeamSystem.Web.Models.Articles;

    public class NewsController : Controller
    {
        private readonly IArticleService articles;
        private readonly UserManager<User> userManager;

        public NewsController(IArticleService articles,
                                  UserManager<User> userManager)
        {
            this.articles = articles;
            this.userManager = userManager;
        }

        //GET: /news/
        public async Task<IActionResult> Index(int page = 1)
            => View(new ArticleListingViewModel
            {
                Articles = await this.articles.AllAsync(page),
                TotalArticles = await this.articles.TotalAsync(),
                CurrentPage = page
            });

        //GET: /news/details
        public async Task<IActionResult> Details(int id)
        {
            var articleFindById = await this.articles.ById(id);

            if (articleFindById == null)
            {
                return NotFound();
            }

            return this.View(articleFindById);
        }

        //GET: /news/search
        public async Task<IActionResult> Search(SearchViewModel model)
        {
            model.Articles = await this.articles.FindAsync(model.SearchText);

            return View(model);
        }
    }
}
