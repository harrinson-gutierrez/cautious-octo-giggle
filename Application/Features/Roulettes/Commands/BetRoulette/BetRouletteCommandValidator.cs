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
            RuleFor(x => x.Number).ExclusiveBetween(0, 36).WithMessage(AppResource["BetRoulette-Validator-Number"]);
            RuleFor(x => x.RouletteId).NotEmpty().NotNull().WithMessage(AppResource["BetRoulette-Validator-RouletteId"]);
            RuleFor(x => x.UserId).NotEmpty().NotNull().WithMessage(AppResource["BetRoulette-Validator-UserId"]);
        }
    }
}
