using BookCatalog.Domain.Abstractions;
using MediatR;

namespace BookCatalog.Application.Abstractions.Messaging
{
    public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
     where TQuery : IQuery<TResponse>
    {
    }
}
