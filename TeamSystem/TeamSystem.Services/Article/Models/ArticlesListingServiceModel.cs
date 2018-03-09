namespace TeamSystem.Services.Article.Models
{
    using AutoMapper;
    using System;
    using System.ComponentModel.DataAnnotations;
    using TeamSystem.Common.Mapping;
    using TeamSystem.Entities;
    using static Data.DataConstants;

    public class ArticlesListingServiceModel : IMapFrom<Articles>, IHaveCustomMapping
    {
        public int Id { get; set; }

        [MinLength(ArticleTitleMinLenght)]
        [MaxLength(ArticleThumbnailMaxLenght)]
        public string Title { get; set; }

        public DateTime PublishDate { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public string ThumbnailUrl { get; set; }

        public void ConfigureMapping(Profile mapper)
            => mapper
                .CreateMap<Articles, ArticlesListingServiceModel>()
                .ForMember(a => a.Author, cfg => cfg.MapFrom(a => a.Author.UserName));
    }
}
