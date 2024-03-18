using MediatR;

namespace Omegahash.Infrastructure.Commands;

public interface ICommand<out TResponse> : IRequest<TResponse>
{

}