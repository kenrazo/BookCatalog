using BookCatalog.Domain.BookCatalog;
using BookCatalog.Infrastructure.EntityFramework.BookCatalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;

namespace BookCatalog.Infrastructure.EntityFramework.DependencyInjections
{
    public static class DependencyInjection
    {
        private const string BookCategory = "BookCategory";

        public static IServiceCollection AddEFCoreInfrastructure(this IServiceCollection services)
        {

            services.AddDbContext<BookCatalogContext>(options =>
            {
                options.UseInMemoryDatabase(BookCategory)
                    .EnableSensitiveDataLogging()
                    .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning));
            });

            services.AddScoped<IBookCatalogRepository, BookCatalogRepository>();
            return services;
        }
    }
}
