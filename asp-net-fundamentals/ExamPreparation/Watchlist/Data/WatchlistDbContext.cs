using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using Watchlist.Data.Models;

using static Watchlist.Data.Models.DataConstraints.UserConstraints;

namespace Watchlist.Data
{
    public class WatchlistDbContext : IdentityDbContext<WatchlistUser, IdentityRole<Guid>, Guid>
    {
        public WatchlistDbContext(DbContextOptions<WatchlistDbContext> options)
            : base(options)
        {
        }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<UserMovie> UsersMovies { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<WatchlistUser>()
                .Property(u => u.UserName)
                .HasMaxLength(MaxUsernameLength)
                .IsRequired();

            builder.Entity<WatchlistUser>()
                .Property(u => u.Email)
                .HasMaxLength(MaxEmailLength)
                .IsRequired();

            builder
                .Entity<Genre>()
                .HasData(new Genre()
                {
                    Id = 1,
                    Name = "Action"
                },
                new Genre()
                {
                    Id = 2,
                    Name = "Comedy"
                },
                new Genre()
                {
                    Id = 3,
                    Name = "Drama"
                },
                new Genre()
                {
                    Id = 4,
                    Name = "Horror"
                },
                new Genre()
                {
                    Id = 5,
                    Name = "Romantic"
                });

            builder.Entity<UserMovie>()
                .HasKey(um => new
                {
                    um.UserId,
                    um.MovieId
                });

            base.OnModelCreating(builder);
        }
    }
}