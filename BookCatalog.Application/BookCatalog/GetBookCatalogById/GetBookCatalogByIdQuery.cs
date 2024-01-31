using BookCatalog.Application.Abstractions.Messaging;

namespace BookCatalog.Application.BookCatalog.GetBookCatalogById
{
    public record GetBookCatalogByIdQuery(Guid? Id) : IQuery<BookCatalogResponse>
    {
    }
}
