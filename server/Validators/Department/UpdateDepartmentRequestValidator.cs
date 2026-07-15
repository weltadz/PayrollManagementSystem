using FluentValidation;
using server.DTOs;

namespace server.Validators;

public class UpdateDepartmentRequestValidator : AbstractValidator<UpdateDepartmentRequestDto>
{
    public UpdateDepartmentRequestValidator()
    {
        RuleFor(x => x.Name)
        .NotEmpty()
        .MaximumLength(60)
        .WithMessage("Name cannot be empty");
    }
}