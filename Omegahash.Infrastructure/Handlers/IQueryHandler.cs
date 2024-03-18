using MediatR;
using Omegahash.Domain.Serializations.Queries;

namespace Omegahash.Infrastructure.Handlers;

public interface IQueryHandler<in TQuery, TResponse> 
    : IRequestHandler<TQuery, TResponse> where TQuery : IQuery<TResponse>
{

}
