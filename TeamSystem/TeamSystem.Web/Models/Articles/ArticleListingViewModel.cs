namespace TeamSystem.Web.Models.Articles
{
    using System;
    using System.Collections.Generic;
    using TeamSystem.Services;
    using TeamSystem.Services.Article.Models;

    public class ArticleListingViewModel
    {
        public IEnumerable<ArticlesListingServiceModel> Articles { get; set; }

        public string SearchText { get; set; }

        public int TotalArticles { get; set; }

        public int TotalPages => (int)Math.Ceiling((double)this.TotalArticles / ServiceConstants.ArticlesPageSize);

        public int CurrentPage { get; set; }

        public int PreviousPage => this.CurrentPage <= 1 ? 1 : this.CurrentPage - 1;

        public int NextPage
            => this.CurrentPage == this.TotalPages
                ? this.TotalPages
                : this.CurrentPage + 1;
    }
}
