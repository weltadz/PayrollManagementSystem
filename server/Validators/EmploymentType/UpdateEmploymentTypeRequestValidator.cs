using FluentValidation;

namespace server.DTOs;

public class UpdateEmploymentTypeRequestValidator : AbstractValidator<UpdateEmploymentTypeRequestDto>
{
    public UpdateEmploymentTypeRequestValidator()
    {
        RuleFor(x => x.Name)
        .NotEmpty()
        .MaximumLength(60)
        .WithMessage("Name cannot be empty");
    }
}