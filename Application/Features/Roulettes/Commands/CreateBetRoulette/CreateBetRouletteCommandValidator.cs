﻿using Application.Enums;
using Application.Interfaces.Resources;
using FluentValidation;

namespace Application.Features.Roulettes.Commands.CreateBetRoulette
{
    public class CreateBetRouletteCommandValidator : AbstractValidator<CreateBetRouletteCommand>
    {
        private readonly IAppResource AppResource;

        public CreateBetRouletteCommandValidator(IAppResource appResource)
        {
            AppResource = appResource;

            When(x => x.Number == null && x.Color == null, () =>
            {
                RuleFor(x => x.Number).InclusiveBetween(0, 36).WithMessage(AppResource["BetRoulette-Validator-Number"]);
                RuleFor(x => x.Color).IsEnumName(typeof(RouletteColor)).WithMessage(AppResource["BetRoulette-Validator-Color"]);
            });

           When(x => x.Number != null, () =>
            {
               RuleFor(x => x.Number).InclusiveBetween(0, 36).WithMessage(AppResource["BetRoulette-Validator-Number"]);
            });

            When(x => x.Color != null, () =>
            {
                RuleFor(x => x.Color).IsEnumName(typeof(RouletteColor)).WithMessage(AppResource["BetRoulette-Validator-Color"]);
            });

            RuleFor(x => x.RouletteId).NotEmpty().NotNull().WithMessage(AppResource["BetRoulette-Validator-RouletteId"]);
        }
    }
}
