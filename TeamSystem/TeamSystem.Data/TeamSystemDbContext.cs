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

        public DbSet<Matches> Matches { get; set; }
        public DbSet<MatchHistories> MatchHistories { get; set; }
        public DbSet<ModelRoles> ModelRoles { get; set; }
        public DbSet<PersonHistories> PersonHistories { get; set; }
        public DbSet<PersonModels> PersonModels { get; set; }
        public DbSet<StartingMembersOfAteam> StartingMembersOfAteam { get; set; }
        public DbSet<StartingPlayers> StartingPlayers { get; set; }
        public DbSet<Teams> Teams { get; set; }
        public DbSet<Articles> Articles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Matches>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.GuestTeamId).HasColumnName("GuestTeam_ID");

                entity.Property(e => e.HomeTeamId).HasColumnName("HomeTeam_ID");

                entity.Property(e => e.MatchDate).HasColumnType("smalldatetime");

                entity.HasOne(d => d.GuestTeam)
                    .WithMany(p => p.MatchesGuestTeam)
                    .HasForeignKey(d => d.GuestTeamId)
                    .HasConstraintName("FK__Matches__GuestTe__22AA2996");

                entity.HasOne(d => d.HomeTeam)
                    .WithMany(p => p.MatchesHomeTeam)
                    .HasForeignKey(d => d.HomeTeamId)
                    .HasConstraintName("FK__Matches__HomeTea__21B6055D");
            });

            modelBuilder.Entity<MatchHistories>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.GuestTeamPlayer).HasMaxLength(150);

                entity.Property(e => e.HomeTeamPlayer).HasMaxLength(150);

                entity.Property(e => e.MatchDate).HasColumnType("smalldatetime");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<ModelRoles>(entity =>
            {
                entity.HasIndex(e => e.Role)
                    .HasName("UQ__ModelRol__DA15413E060DEAE8")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<PersonHistories>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FullName)
                    .HasColumnName("Full_Name")
                    .HasMaxLength(100);

                entity.Property(e => e.PreviousTeam).HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<PersonModels>(entity =>
            {
                entity.HasIndex(e => e.Ucn)
                    .HasName("UQ__PersonMo__C5B186D20CBAE877")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MiddleName).HasMaxLength(50);

                entity.Property(e => e.ModelRoleId).HasColumnName("ModelRole_ID");

                entity.Property(e => e.TeamId).HasColumnName("Team_ID");

                entity.Property(e => e.Ucn)
                    .IsRequired()
                    .HasColumnName("UCN")
                    .HasColumnType("nchar(10)");

                entity.HasOne(d => d.ModelRole)
                    .WithMany(p => p.PersonModels)
                    .HasForeignKey(d => d.ModelRoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PersonMod__Model__0F975522");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.PersonModels)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PersonMod__Team___0EA330E9");
            });

            modelBuilder.Entity<StartingMembersOfAteam>(entity =>
            {
                entity.ToTable("StartingMembersOfATeam");

                entity.HasIndex(e => e.TeamId)
                    .HasName("UQ__Starting__02215C0B15502E78")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.TeamId).HasColumnName("Team_ID");

                entity.HasOne(d => d.Team)
                    .WithOne(p => p.StartingMembersOfAteam)
                    .HasForeignKey<StartingMembersOfAteam>(d => d.TeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__StartingM__Team___173876EA");
            });

            modelBuilder.Entity<StartingPlayers>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.MemberId).HasColumnName("Member_ID");

                entity.Property(e => e.PlayerId).HasColumnName("Player_ID");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.StartingPlayers)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK__StartingP__Membe__1BFD2C07");

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.StartingPlayers)
                    .HasForeignKey(d => d.PlayerId)
                    .HasConstraintName("FK__StartingP__Playe__1CF15040");
            });

            modelBuilder.Entity<Teams>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.TeamName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Articles>(entity =>
            {
                entity.Property(e => e.AuthorId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasMaxLength(600);

                entity.Property(e => e.PublishDate).HasColumnType("smalldatetime");

                entity.Property(e => e.ThumbnailUrl)
                    .IsRequired()
                    .HasMaxLength(2040);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Articles)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Articles__Author__59063A47");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
