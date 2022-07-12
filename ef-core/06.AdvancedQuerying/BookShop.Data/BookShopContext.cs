using Microsoft.EntityFrameworkCore;

using BookShop.Models;

namespace BookShop.Data
{
    public class BookShopContext : DbContext
    {
		public BookShopContext() { }

		public BookShopContext(DbContextOptions options)
			: base(options) { }
		
        public DbSet<Book> Books { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<BookCategory> BooksCategories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookCategory>()
                .HasKey(x => new { x.BookId, x.CategoryId });

            modelBuilder.Entity<BookCategory>()
                .HasOne(e => e.Category)
                .WithMany(c => c.CategoryBooks)
                .HasForeignKey(e => e.CategoryId);

            modelBuilder.Entity<BookCategory>()
                .HasOne(x => x.Book)
                .WithMany(c => c.BookCategories)
                .HasForeignKey(e => e.BookId);
        }
    }
}
