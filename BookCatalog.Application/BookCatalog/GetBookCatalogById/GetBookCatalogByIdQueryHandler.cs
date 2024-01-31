using Ardalis.GuardClauses;
using AutoMapper;
using BookCatalog.Application.Abstractions.Messaging;
using BookCatalog.Domain.Abstractions;
using BookCatalog.Domain.BookCatalog;

namespace BookCatalog.Application.BookCatalog.GetBookCatalogById
{
    public class GetBookCatalogByIdQueryHandler : IQueryHandler<GetBookCatalogByIdQuery, BookCatalogResponse>
    {
        private readonly IBookCatalogRepository _bookCatalogRepository;
        private readonly IMapper _mapper;
        public GetBookCatalogByIdQueryHandler(IBookCatalogRepository bookCatalogRepository, IMapper mapper)
        {
            Guard.Against.Null(bookCatalogRepository, nameof(bookCatalogRepository));
            Guard.Against.Null(mapper, nameof(mapper));
            _bookCatalogRepository = bookCatalogRepository;
            _mapper = mapper;
        }

        public async Task<Result<BookCatalogResponse>> Handle(GetBookCatalogByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _bookCatalogRepository.GetById(request.Id.Value);

            if (result is null)
            {
                return Result.Failure<BookCatalogResponse>(BookCatalogErrors.NotFound);
            }

            return _mapper.Map<BookCatalogResponse>(result);
        }
    }
}
