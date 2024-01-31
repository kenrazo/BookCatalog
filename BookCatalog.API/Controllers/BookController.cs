using BookCatalog.Application.BookCatalog;
using BookCatalog.Application.BookCatalog.GetBookCatalogById;
using BookCatalog.Application.BookCatalog.GetBookCatalogs;
using BookCatalog.Application.BookCatalog.GetBookCatalogsByDateRange;
using BookCatalog.Domain.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookCatalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(BookCatalogResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetBookCatalogByIdQuery(id), cancellationToken);

            return HandleResult(result);

        }

        [HttpGet("GetAll")]
        [ProducesResponseType(typeof(IEnumerable<GetBookCatalogsResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(int pageNumber,
            int itemsPerPage,
            CancellationToken cancellationToken)
        {
            var result = await _mediator
                .Send(new GetBookCatalogsQuery(pageNumber, itemsPerPage),
                cancellationToken);

            return HandleResult(result);

        }

        [HttpGet("GetByDateRange")]
        [ProducesResponseType(typeof(IEnumerable<GetBookCatalogsResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(string startDate,
            string endDate,
            int pageNumber,
            int itemsPerPage,
            CancellationToken cancellationToken)
        {
            var result = await _mediator
                .Send(new GetBookCatalogsByDateRangeQuery(startDate,
                endDate,
                pageNumber,
                itemsPerPage),
                cancellationToken);

            return HandleResult(result);

        }

        private IActionResult HandleResult<T>(Result<T> result)
        {
            if (result.IsFailure)
            {
                return NotFound(new ProblemDetails
                {
                    Status = StatusCodes.Status404NotFound,
                    Type = result.Error.Code,
                    Title = result.Error.Code,
                    Detail = result.Error.Name,
                });
            }

            return Ok(result.Value);
        }
    }
}
