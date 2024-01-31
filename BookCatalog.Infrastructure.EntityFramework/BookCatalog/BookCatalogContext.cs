using BookCatalog.Domain.BookCatalog;
using Microsoft.EntityFrameworkCore;

namespace BookCatalog.Infrastructure.EntityFramework.BookCatalog
{
    public class BookCatalogContext : DbContext
    {
        public BookCatalogContext(DbContextOptions<BookCatalogContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(build =>
            {
                build.HasKey(entry => entry.Id);
                build.Property(entry => entry.Id).ValueGeneratedOnAdd();
                build.HasOne(entry => entry.Category)
                .WithMany()
                .HasForeignKey(entry => entry.CategoryId);
            });

            modelBuilder.Entity<Category>(build =>
            {
                build.HasKey(entry => entry.Id);
                build.Property(entry => entry.Id).ValueGeneratedOnAdd();
            });
        }
    }
}
