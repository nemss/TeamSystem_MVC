﻿namespace TeamSystem.Entities
{
    using System;

    public partial class Articles
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ThumbnailUrl { get; set; }
        public DateTime PublishDate { get; set; }
        public string AuthorId { get; set; }

        public User Author { get; set; }
    }
}
