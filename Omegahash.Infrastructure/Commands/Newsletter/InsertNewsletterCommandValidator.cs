using FluentValidation;

namespace Omegahash.Infrastructure.Commands.Newsletter;

public sealed class InsertNewsletterCommandValidator : AbstractValidator<InsertNewsletterCommand>
{
    public InsertNewsletterCommandValidator()
    {
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
    }
}
