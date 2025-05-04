using FluentValidation;
using JobApplicationTracker.Handlers;

namespace JobApplicationTracker.Validators;

public sealed class CreateApplicationValidator : AbstractValidator<CreateApplicationCommand>
{
    public CreateApplicationValidator()
    {
        RuleFor(command => command.Company)
            .NotEmpty()
            .WithMessage("Company can't be empty.");

        RuleFor(command => command.Position)
            .NotEmpty()
            .WithMessage("Position can't be empty.");
    }
}