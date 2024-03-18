using MediatR;

namespace Omegahash.Domain.Serializations.Commands;

public interface ICommand<out TResponse> : IRequest<TResponse>
{

}