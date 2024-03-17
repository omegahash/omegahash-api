using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Omegahash.Domain.Serializations.Commands;

public struct InsertNewsletterCommand : IRequest<string>
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
}
