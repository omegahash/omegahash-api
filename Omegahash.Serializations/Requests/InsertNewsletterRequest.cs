using System.ComponentModel.DataAnnotations;

namespace Omegahash.Domain.Serializations.Requests;

public struct InsertNewsletterRequest
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
}
