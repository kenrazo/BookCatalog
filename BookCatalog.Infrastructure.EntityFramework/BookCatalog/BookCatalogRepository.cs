using Ardalis.GuardClauses;
using BookCatalog.Domain.Abstractions;
using BookCatalog.Domain.BookCatalog;
using Microsoft.EntityFrameworkCore;

namespace BookCatalog.Infrastructure.EntityFramework.BookCatalog
{
    public class BookCatalogRepository : IBookCatalogRepository
    {
        private readonly BookCatalogContext _context;

        public BookCatalogRepository(BookCatalogContext context)
        {
            Guard.Against.Null(context, nameof(context));
            _context = context;
        }

        public async Task<Book> GetById(Guid id) =>
                await _context.Books.Where(m => m.Id == id)
                .Include(m => m.Category).FirstOrDefaultAsync();

        public async Task<PaginationResult<Book>> GetBookCatalogs(
            int pageNumber, int itemsPerPage)
        {
            var query = _context.Books
            .AsQueryable()
            .Include(b => b.Category)
            .AsNoTracking();

            var totalItems = await query.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalItems / itemsPerPage);

            var books = await query
                .OrderBy(b => b.PublishDateUtc)
                .Skip((pageNumber - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .ToListAsync();

            var paginationResult = new PaginationResult<Book>
            {
                Datas = books,
                PageNumber = pageNumber,
                ItemsPerPage = itemsPerPage,
                TotalRecords = totalItems,
                NumberOfPages = totalPages
            };

            return paginationResult;
        }

        public async Task<PaginationResult<Book>> GetBookCategoriesByDateRange(int pageNumber,
            int itemsPerPage,
            DateTime? startDate,
            DateTime? endDate)
        {
            var query = _context.Books
                .AsQueryable()
                .Include(b => b.Category)
                .AsNoTracking();

            if (startDate.HasValue)
            {
                query = query.Where(b => b.PublishDateUtc >= startDate);
            }

            if (endDate.HasValue)
            {
                query = query.Where(b => b.PublishDateUtc <= endDate);
            }

            var totalItems = await query.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalItems / itemsPerPage);

            var books = await query
                .OrderBy(b => b.PublishDateUtc)
                .Skip((pageNumber - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .ToListAsync();

            var paginationResult = new PaginationResult<Book>
            {
                Datas = books,
                PageNumber = pageNumber,
                ItemsPerPage = itemsPerPage,
                TotalRecords = totalItems,
                NumberOfPages = totalPages
            };

            return paginationResult;
        }

    }

}


