using MediatR;

namespace Omegahash.Domain.Serializations.Queries;

public interface IQuery<out TResponse> : IRequest<TResponse>
{

}