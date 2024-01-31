using BookCatalog.Application.Abstractions.Messaging;

namespace BookCatalog.Application.BookCatalog.GetBookCatalogs
{
    public record GetBookCatalogsQuery(int PageNumber, int ItemsPerPage) : IQuery<GetBookCatalogsResponse>;
}
