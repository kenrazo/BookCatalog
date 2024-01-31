using Ardalis.GuardClauses;
using AutoMapper;
using BookCatalog.Application.Abstractions.Messaging;
using BookCatalog.Domain.Abstractions;
using BookCatalog.Domain.BookCatalog;

namespace BookCatalog.Application.BookCatalog.GetBookCatalogs
{
    public class GetBookCatalogsQueryHandler : IQueryHandler<GetBookCatalogsQuery, GetBookCatalogsResponse>
    {
        private readonly IBookCatalogRepository _bookCatalogRepository;
        private readonly IMapper _mapper;

        public GetBookCatalogsQueryHandler(IBookCatalogRepository bookCatalogRepository, IMapper mapper)
        {
            Guard.Against.Null(bookCatalogRepository, nameof(bookCatalogRepository));
            Guard.Against.Null(mapper, nameof(mapper));
            _bookCatalogRepository = bookCatalogRepository;
            _mapper = mapper;
        }

        public async Task<Result<GetBookCatalogsResponse>> Handle(GetBookCatalogsQuery request,
            CancellationToken cancellationToken)
        {
            var data = await _bookCatalogRepository.GetBookCatalogs(request.PageNumber, request.ItemsPerPage);

            if (data.Datas is null || !data.Datas.Any())
            {
                return Result.Failure<GetBookCatalogsResponse>(
                    BookCatalogErrors.PaginationNotFound(request.PageNumber, request.ItemsPerPage));
            }

            var result = _mapper.Map<GetBookCatalogsResponse>(data);
            result.BookCatalogs = _mapper.Map<List<BookCatalogResponse>>(data.Datas);

            return result;
        }
    }
}
