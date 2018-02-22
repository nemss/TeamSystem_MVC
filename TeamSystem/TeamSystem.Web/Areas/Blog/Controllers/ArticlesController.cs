namespace TeamSystem.Web.Areas.Blog.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using TeamSystem.Data.Models;
    using TeamSystem.Services.Blog.Interfaces;
    using TeamSystem.Services.Html;
    using TeamSystem.Web.Areas.Blog.Models;
    using TeamSystem.Web.Infrastructure.Filters;

    [Area(WebConstants.BlogArea)]
    [Authorize(Roles = WebConstants.BlogAuthorRole)]
    public class ArticlesController : Controller
    {
        private readonly IBlogArticleService articles;
        private readonly UserManager<User> userManager;
        private readonly IHtmlService html;

        public ArticlesController(IBlogArticleService articles,
                                 UserManager<User> userManager,
                                 IHtmlService html)
        {
            this.articles = articles;
            this.userManager = userManager;
            this.html = html;
        }

        //GET: /blog/articles/create
        public IActionResult Create() => View();

        //POST: /blog/articles/create
        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Create(ArticleFormModel model)
        {
            model.Content = this.html.Sanitize(model.Content);

            var userId = this.userManager.GetUserId(User);

            await this.articles.CreateAsync(model.Title, model.Content, model.ThumbnailUrl, userId);

            return RedirectToAction(
                nameof(Web.Controllers.HomeController.Index),
                "Articles",
                new { area = string.Empty });
        }
    }
}
