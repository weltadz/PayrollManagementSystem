using FluentValidation;
using server.DTOs;

namespace server.Validators.User;

public class CreateUserRequestValidator : AbstractValidator<CreateUserRequestDto>
{
    public CreateUserRequestValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty()
            .MaximumLength(60)
            .WithMessage("Username cannot be empty");

        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress()
            .MaximumLength(100)
            .WithMessage("Email cannot be empty");

        RuleFor(x => x.PasswordHash)
            .NotEmpty()
            .MaximumLength(60)
            .WithMessage("Password cannot be empty");

        RuleFor(x => x.RoleId)
            .NotEmpty()
            .WithMessage("Role id cannot be empty");
    }
}