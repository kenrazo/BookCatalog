using BookCatalog.Domain.Abstractions;

namespace BookCatalog.Domain.BookCatalog
{
    public interface IBookCatalogRepository
    {
        Task<Book> GetById(Guid id);

        Task<PaginationResult<Book>> GetBookCatalogs(
            int pageNumber, int itemsPerPage);

        Task<PaginationResult<Book>> GetBookCategoriesByDateRange(int pageNumber,
            int itemsPerPage,
            DateTime? startDate,
            DateTime? endDate);
    }
}
