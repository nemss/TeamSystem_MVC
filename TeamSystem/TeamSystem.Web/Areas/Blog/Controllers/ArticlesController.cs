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
    using TeamSystem.Web.Infrastructure.Extensions;
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

        //GET: /blog/articles/edit/{id}
        public async Task<IActionResult> Edit(int id)
        {
            var articleFindById = await this.articles.ById(id);

            if (articleFindById == null)
            {
                return NotFound();
            }

            return View(new ArticleFormModel
            {
                Title = articleFindById.Title,
                Content = articleFindById.Content,
                ThumbnailUrl = articleFindById.ThumbnailUrl
            });
        }

        //POST: /blog/articles/edit/{id}
        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Edit(int id, ArticleFormModel model)
        {
            await this.articles.EditAsync(id, model.Title, model.Content, model.ThumbnailUrl);

            TempData.AddSuccessMessage($"Article {model.Title} successfully edited!");

            return RedirectToAction(
                nameof(Web.Controllers.NewsController.Index),
                "Articles",
                new { area = string.Empty });
        }

        //GET: /blog/articles/delete/{id}
        public async Task<IActionResult> Delete(int id)
        {
            var articleFindById = await this.articles.ById(id);

            if (articleFindById == null)
            {
                return NotFound();
            }

            return View(new ArticleFormModel
            {
                Id = articleFindById.Id,
                Title = articleFindById.Title,
                Content = articleFindById.Content,
                ThumbnailUrl = articleFindById.ThumbnailUrl
            });
        }

        //POST: /blog/articles/delete/{id}
        [HttpPost]
        public async Task<IActionResult> Destroy(int id)
        {
            var articleFindById = await this.articles.ById(id);

            if (articleFindById == null)
            {
                return NotFound();
            }

            await this.articles.DeleteAsync(id);

            TempData.AddSuccessMessage($"Article {articleFindById.Title} successfully deleted!");

            return RedirectToAction(
                nameof(Web.Controllers.NewsController.Index),
                "Articles",
                new { area = string.Empty });
        }
    }
}
