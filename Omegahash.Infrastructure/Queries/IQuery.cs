using MediatR;

namespace Omegahash.Infrastructure.Queries;

public interface IQuery<out TResponse> : IRequest<TResponse>
{

}