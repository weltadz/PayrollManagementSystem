using FluentValidation;
using server.DTOs;

namespace server.Validators;

public class CreateDepartmentRequestValidator : AbstractValidator<CreateDepartmentRequestDto>
{
    public CreateDepartmentRequestValidator()
    {
        RuleFor(x => x.Name)
        .NotEmpty()
        .MaximumLength(60)
        .WithMessage("Name cannot be empty");
    }
}