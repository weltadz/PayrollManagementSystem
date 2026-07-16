using FluentValidation;
using server.DTOs;

namespace server.Validators;

public class CreateEmploymentTypeRequestValidator : AbstractValidator<CreateEmploymentTypeRequestDto>
{
    public CreateEmploymentTypeRequestValidator()
    {
        RuleFor(x => x.Name)
        .NotEmpty()
        .MaximumLength(60)
        .WithMessage("Name cannot be empty");
    }
}