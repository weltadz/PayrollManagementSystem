using FluentValidation;
using server.DTOs;

namespace server.Validators;

public class UpdatePositionRequestValidator : AbstractValidator<UpdatePositionRequestDto>
{
    public UpdatePositionRequestValidator()
    {
        RuleFor(x => x.Name)
        .NotEmpty()
        .MaximumLength(60)
        .WithMessage("Name must not be empty");
    }
}