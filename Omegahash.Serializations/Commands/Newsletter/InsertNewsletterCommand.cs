using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Omegahash.Domain.Serializations.Commands.Newsletter;

public struct InsertNewsletterCommand : IRequest
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
}
