using Application.DTOs.Authentication;
using Application.DTOs.Roulettes;
using Application.Features.Roulettes.Commands.BetRoulette;
using Application.Interfaces.Resources;
using FluentValidation;

namespace Application.Features.Roulettes.Commands
{
    public class BetRouletteCommandValidator : AbstractValidator<BetRouletteCommand>
    {
        private readonly IAppResource AppResource;

        public BetRouletteCommandValidator(IAppResource appResource)
        {
            AppResource = appResource;
            When(x => x.Number != null, () =>
            {
               RuleFor(x => x.Number).ExclusiveBetween(0, 36).WithMessage(AppResource["BetRoulette-Validator-Number"]);
            });

            When(x => x.Color != null, () =>
            {
                RuleFor(x => x.Color).IsEnumName(typeof(RouletteColor)).WithMessage(AppResource["BetRoulette-Validator-Color"]);
            });

            RuleFor(x => x.RouletteId).NotEmpty().NotNull().WithMessage(AppResource["BetRoulette-Validator-RouletteId"]);
            //RuleFor(x => x.UserId).NotEmpty().NotNull().WithMessage(AppResource["BetRoulette-Validator-UserId"]);
        }
    }
}
