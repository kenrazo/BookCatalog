using BookCatalog.Application.Abstractions.Messaging;

namespace BookCatalog.Application.BookCatalog.GetBookCatalogsByDateRange
{
    public record GetBookCatalogsByDateRangeQuery(string StartDate,
        string EndDate,
        int PageNumber,
        int ItemsPerPage) : IQuery<GetBookCatalogsByDateRangeResponse>;
}
