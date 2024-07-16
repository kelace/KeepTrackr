using Authorization.Api.Services.Authentication;
using FluentValidation;

namespace Authorization.Api.Validators
{
    public class SignUpValidator : AbstractValidator<SignUpUser>
    {
        public SignUpValidator()
        {
            RuleFor(t => t.Name).NotEmpty();
            RuleFor(t => t.Password).NotEmpty();
            RuleFor(t => t.ConfirmPassword).Equal(t => t.Password);
        }
    }
}
