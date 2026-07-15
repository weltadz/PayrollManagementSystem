using FluentValidation;
using server.DTOs;

namespace server.Validators;

public class CreatePositionRequestValidator : AbstractValidator<CreatePositionRequestDto>
{
    public CreatePositionRequestValidator()
    {
        RuleFor(x => x.Name)
        .NotEmpty()
        .MaximumLength(60)
        .WithMessage("Name must not be empty");
    }
}