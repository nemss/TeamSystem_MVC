namespace TeamSystem.Web.Models.Articles
{
    using System.Collections.Generic;
    using TeamSystem.Services.Article.Models;

    public class SearchViewModel
    {
        public IEnumerable<ArticlesListingServiceModel> Articles { get; set; }
          = new List<ArticlesListingServiceModel>();

        public string SearchText { get; set; }
    }
}
