using MediatR;
using Omegahash.Infrastructure.Queries;

namespace Omegahash.Infrastructure.Handlers;

public interface IQueryHandler<in TQuery, TResponse> 
    : IRequestHandler<TQuery, TResponse> where TQuery : IQuery<TResponse>
{

}
