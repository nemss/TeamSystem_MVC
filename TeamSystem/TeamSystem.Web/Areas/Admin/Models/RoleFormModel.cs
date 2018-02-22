﻿namespace TeamSystem.Web.Areas.Admin.Models
{
    using System.ComponentModel.DataAnnotations;

    public abstract class RoleFormModel
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        public string Role { get; set; }
    }
}