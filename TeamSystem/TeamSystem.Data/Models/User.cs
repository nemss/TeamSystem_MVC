namespace TeamSystem.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.Collections;
    using System.Collections.Generic;

    public class User : IdentityUser
    {
        public ICollection<Articles> Articles { get; set; }
    }
}
