using FluentValidation;

namespace Omegahash.Domain.Serializations.Commands.Newsletter;

public sealed class InsertNewsletterCommandValidator : AbstractValidator<InsertNewsletterCommand>
{
    public InsertNewsletterCommandValidator()
    {
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
    }
}
