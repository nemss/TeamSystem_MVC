namespace TeamSystem.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using TeamSystem.Data.Models;

    public class TeamSystemDbContext : IdentityDbContext<User>
    {
        public TeamSystemDbContext(DbContextOptions<TeamSystemDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
