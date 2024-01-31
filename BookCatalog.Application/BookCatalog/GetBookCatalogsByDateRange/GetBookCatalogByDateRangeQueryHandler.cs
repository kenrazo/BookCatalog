using Ardalis.GuardClauses;
using AutoMapper;
using BookCatalog.Application.Abstractions.Messaging;
using BookCatalog.Application.Extensions;
using BookCatalog.Domain.Abstractions;
using BookCatalog.Domain.BookCatalog;

namespace BookCatalog.Application.BookCatalog.GetBookCatalogsByDateRange
{
    public class GetBookCatalogByDateRangeQueryHandler : IQueryHandler<GetBookCatalogsByDateRangeQuery, GetBookCatalogsByDateRangeResponse>
    {
        private readonly IBookCatalogRepository _bookCatalogRepository;
        private readonly IMapper _mapper;

        public GetBookCatalogByDateRangeQueryHandler(IBookCatalogRepository bookCatalogRepository, IMapper mapper)
        {
            Guard.Against.Null(bookCatalogRepository, nameof(bookCatalogRepository));
            Guard.Against.Null(mapper, nameof(mapper));
            _bookCatalogRepository = bookCatalogRepository;
            _mapper = mapper;
        }

        public async Task<Result<GetBookCatalogsByDateRangeResponse>> Handle(GetBookCatalogsByDateRangeQuery request,
            CancellationToken cancellationToken)
        {
            var data = await _bookCatalogRepository.GetBookCategoriesByDateRange(request.PageNumber,
                request.ItemsPerPage, request.StartDate.ToUtcDateTime(), request.EndDate.ToUtcDateTime());

            if (data.Datas is null || !data.Datas.Any())
            {
                return Result.Failure<GetBookCatalogsByDateRangeResponse>(
                    BookCatalogErrors.DateRangeNotFound(request.StartDate,
                    request.EndDate,
                    request.PageNumber,
                    request.ItemsPerPage));
            }

            var result = _mapper.Map<GetBookCatalogsByDateRangeResponse>(data);
            result.BookCatalogs = _mapper.Map<List<BookCatalogResponse>>(data.Datas);

            return result;
        }

    }
}
