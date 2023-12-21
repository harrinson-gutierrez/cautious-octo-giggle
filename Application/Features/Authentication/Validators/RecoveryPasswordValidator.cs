using Application.DTOs.Authentication;
using Application.Interfaces.Resources;
using FluentValidation;

namespace Application.Features.Authentication.Validators
{
    public class RecoveryPasswordValidator : AbstractValidator<RecoveryPasswordRequest>
    {
        private readonly IAppResource AppResource;

        public RecoveryPasswordValidator(IAppResource appResource)
        {
            AppResource = appResource;

            RuleFor(x => x.Email).NotEmpty().NotNull().WithMessage(AppResource["ValidationRecoveryPasswordEmail"]);
        }

    }
}
