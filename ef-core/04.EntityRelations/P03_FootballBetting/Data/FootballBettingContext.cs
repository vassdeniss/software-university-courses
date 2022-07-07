using Microsoft.EntityFrameworkCore;

using P03_FootballBetting.Data.Models;

namespace P03_FootballBetting.Data
{
    public class FootballBettingContext : DbContext
    {
        public FootballBettingContext() { }

        public FootballBettingContext(DbContextOptions dbContextOptions) 
            : base(dbContextOptions) { }

        public virtual DbSet<Color> Colors { get; set; }

        public virtual DbSet<Country> Countries { get; set; }

        public virtual DbSet<Position> Positions { get; set; }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Town> Towns { get; set; }

        public virtual DbSet<Team> Teams { get; set; }

        public virtual DbSet<Player> Players { get; set; }

        public virtual DbSet<Bet> Bets { get; set; }

        public virtual DbSet<Game> Games { get; set; }

        public virtual DbSet<PlayerStatistic> PlayerStatistics { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Config.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .Property(p => p.Balance)
                .HasDefaultValue(0.0m);

            modelBuilder.Entity<Team>()
                .Property(p => p.Budget)
                .HasDefaultValue(0.0m);

            modelBuilder.Entity<Team>()
                .HasOne(x => x.PrimaryKitColor)
                .WithMany(x => x.PrimaryKitTeams)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(x => x.PrimaryKitColorId);

            modelBuilder.Entity<Team>()
                .HasOne(x => x.SecondaryKitColor)
                .WithMany(x => x.SecondaryKitTeams)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(x => x.SecondaryKitColorId);

            modelBuilder.Entity<Game>()
                .HasOne(x => x.HomeTeam)
                .WithMany(x => x.HomeGames)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(x => x.HomeTeamId);

            modelBuilder.Entity<Game>()
                .HasOne(x => x.AwayTeam)
                .WithMany(x => x.AwayGames)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(x => x.AwayTeamId);

            modelBuilder.Entity<PlayerStatistic>()
                .HasKey(x => new { x.PlayerId, x.GameId });
        }
    }
}
