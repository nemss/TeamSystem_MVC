namespace TeamSystem.Services.Blog.Models
{
    using AutoMapper;
    using System;
    using System.ComponentModel.DataAnnotations;
    using TeamSystem.Common.Mapping;
    using TeamSystem.Data.Models;

    public class BlogArticleDetailsServiceModel : IMapFrom<Articles>, IHaveCustomMapping
    {
        public int Id { get; set; }

        [MinLength(5)]
        [MaxLength(100)]
        public string Title { get; set; }

        public string Content { get; set; }

        public string ThumbnailUrl { get; set; }

        public DateTime PublishDate { get; set; }

        public string Author { get; set; }

        public void ConfigureMapping(Profile mapper)
            => mapper
                .CreateMap<Articles, BlogArticleDetailsServiceModel>()
                .ForMember(a => a.Author, cfg => cfg.MapFrom(a => a.Author.UserName));
    }
}
