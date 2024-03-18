using MediatR;
using Omegahash.Domain.Serializations.Commands;

namespace Omegahash.Infrastructure.Handlers;

public interface ICommandHandler<in TCommand, TResponse>
    : IRequestHandler<TCommand, TResponse> where TCommand : ICommand<TResponse>
{

}
