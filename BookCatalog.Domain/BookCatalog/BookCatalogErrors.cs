using BookCatalog.Domain.Abstractions;

namespace BookCatalog.Domain.BookCatalog
{
    public static class BookCatalogErrors
    {
        public static Error NotFound = new("GetBookCatalogById.NotFound", "The book with specified identifer was not found");
        public static Error PaginationNotFound(int pageNumber, int itemsPerPage) => new("GetBookCatalogs.NotFound", $"No data found for PageNumber: {pageNumber}, ItemPerPage: {itemsPerPage}");

        public static Error DateRangeNotFound(string startDate,
            string endDate,
            int pageNumber,
            int itemsPerPage) => new("GetBookCatalogsByDateRange.NotFound", $"No data found for StartDate: {startDate}, EndDate: {endDate}, PageNumber: {pageNumber}, ItemPerPage: {itemsPerPage}");
    }
}
