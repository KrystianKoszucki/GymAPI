using FluentValidation;
using GymAPI.ModelsDTO;

namespace GymAPI.Models.Validators
{
    public class RegisterUserDtoValidator: AbstractValidator<RegisterUserDto>
    {
        public RegisterUserDtoValidator(GymDbContext dbContext)
        {
            RuleFor(a => a.Email).NotEmpty().EmailAddress();

            RuleFor(b => b.Password).MinimumLength(8);

            RuleFor(c => c.ConfirmPassword).Equal(d => d.Password);

            RuleFor(e => e.Email)
                .Custom((value, context) =>
                {
                    var usedEmail = dbContext.Users.Any(f => f.Email == value);

                    if (usedEmail)
                    {
                        context.AddFailure("Email", "That email is already taken.");
                    }
                });
        }



    }
}
