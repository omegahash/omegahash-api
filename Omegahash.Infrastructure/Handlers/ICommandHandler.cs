using MediatR;
using Omegahash.Infrastructure.Commands;

namespace Omegahash.Infrastructure.Handlers;

public interface ICommandHandler<in TCommand, TResponse>
    : IRequestHandler<TCommand, TResponse> where TCommand : ICommand<TResponse>
{

}
