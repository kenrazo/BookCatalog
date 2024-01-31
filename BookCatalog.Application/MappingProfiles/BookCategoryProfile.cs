using AutoMapper;
using BookCatalog.Application.BookCatalog;
using BookCatalog.Application.BookCatalog.GetBookCatalogs;
using BookCatalog.Application.BookCatalog.GetBookCatalogsByDateRange;
using BookCatalog.Domain.Abstractions;
using BookCatalog.Domain.BookCatalog;

namespace BookCatalog.Application.MappingProfiles
{
    public class BookCategoryProfile : Profile
    {
        public BookCategoryProfile()
        {
            CreateMap<Book, BookCatalogResponse>()
                .ForMember(d => d.Category,
                opt => opt.MapFrom(s => s.Category.Name));

            CreateMap<PaginationResult<Book>, GetBookCatalogsResponse>();
            CreateMap<PaginationResult<Book>, GetBookCatalogsByDateRangeResponse>();
        }
    }
}
