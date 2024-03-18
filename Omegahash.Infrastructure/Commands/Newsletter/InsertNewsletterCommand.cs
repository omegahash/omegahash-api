using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Omegahash.Infrastructure.Commands.Newsletter;

public struct InsertNewsletterCommand : IRequest
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
}
