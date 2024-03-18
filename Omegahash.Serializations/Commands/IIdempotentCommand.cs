namespace Omegahash.Domain.Serializations.Commands;

public interface IIdempotentCommand<out TResponse> : ICommand<TResponse>
{
    Guid RequestId { get; set; }
}