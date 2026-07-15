using FluentValidation;
using server.DTOs;

namespace server.Validators.User;

public class UpdateUserRequestValidator : AbstractValidator<UpdateUserRequestDto>
{
    public UpdateUserRequestValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage("User id cannot be empty");

        RuleFor(x => x.Username)
            .NotEmpty()
            .MaximumLength(60)
            .WithMessage("Username cannot be empty");

        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress()
            .MaximumLength(100)
            .WithMessage("Email cannot be empty");

        RuleFor(x => x.RoleId)
            .NotEmpty()
            .WithMessage("Role id cannot be empty");
    }
}