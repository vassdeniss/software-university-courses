namespace MusicHub.Data
{
    using Microsoft.EntityFrameworkCore;

    using MusicHub.Data.Models;

    public class MusicHubDbContext : DbContext
    {
        public MusicHubDbContext()
        {
        }

        public MusicHubDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public virtual DbSet<Album> Albums { get; set; }

        public virtual DbSet<Performer> Performers { get; set; }

        public virtual DbSet<Producer> Producers { get; set; }

        public virtual DbSet<Song> Songs { get; set; }

        public virtual DbSet<SongPerformer> SongsPerformers { get; set; }

        public virtual DbSet<Writer> Writers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<SongPerformer>()
                .HasKey(x => new { x.SongId, x.PerformerId });
        }
    }
}
