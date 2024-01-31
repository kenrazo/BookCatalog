using BookCatalog.Domain.BookCatalog;
using BookCatalog.Infrastructure.EntityFramework.BookCatalog;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace BookCatalog.Infrastructure.EntityFramework
{
    public class SampleData
    {
        public static void Initialize(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            var context = serviceScope.ServiceProvider.GetService<BookCatalogContext>();
            var guids = PopulateCategories(context);

            context.Books.AddRange(
                Book.Create(guids.FirstOrDefault(), "Book of Me",
                "ITs a book called ME",
                Convert.ToDateTime("2023-01-29")),
                Book.Create(guids.FirstOrDefault(), "Book of You",
                "ITs a book called You",
                Convert.ToDateTime("2023-01-31")),
                Book.Create(guids.LastOrDefault(), "Book of Moon",
                "ITs a book called Moon",
                Convert.ToDateTime("2024-01-28")),
                Book.Create(guids.LastOrDefault(), "Book of Sun",
                "ITs a book called Sun",
                Convert.ToDateTime("2023-01-31")),
                 Book.Create(guids.FirstOrDefault(), "Book of Tree",
                "ITs a book called Tree",
                Convert.ToDateTime("2023-01-29")),
                Book.Create(guids.FirstOrDefault(), "Book of Stone",
                "ITs a book called Stone",
                Convert.ToDateTime("2023-01-31")),
                Book.Create(guids.LastOrDefault(), "Book of Water",
                "ITs a book called Water",
                Convert.ToDateTime("2024-01-28")),
                Book.Create(guids.LastOrDefault(), "Book of Earth",
                "ITs a book called Earth",
                Convert.ToDateTime("2024-01-31")),
                Book.Create(guids.LastOrDefault(), "Book of Air",
                "ITs a book called Air",
                Convert.ToDateTime("2023-01-07")),
                Book.Create(guids.LastOrDefault(), "Book of Light",
                "ITs a book called Light",
                Convert.ToDateTime("2024-01-01")));

            context.SaveChanges();

            var a = context.Books.ToList();
        }

        private static List<Guid> PopulateCategories(BookCatalogContext? context)
        {
            context.Database.EnsureCreated();

            context.Categories.AddRange(Category.Create("Adventure"),
                Category.Create("Fantasy"),
                Category.Create("Suspense"),
                Category.Create("Crime"));

            context.SaveChanges();

            return context.Categories.Select(m => m.Id).ToList();
        }
    }
}
