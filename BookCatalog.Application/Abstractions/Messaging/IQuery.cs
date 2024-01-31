using BookCatalog.Domain.Abstractions;
using MediatR;

namespace BookCatalog.Application.Abstractions.Messaging
{
    public interface IQuery<TResponse> : IRequest<Result<TResponse>>
    {
    }
}
