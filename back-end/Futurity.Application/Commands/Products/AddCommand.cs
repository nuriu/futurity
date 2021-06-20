using FluentValidation;
using Futurity.Persistence.ViewModels;
using MediatR;

namespace Futurity.Application.Commands.Products
{
    public class AddCommand : ProductViewModel, IRequest
    {
    }

    public class AddCommandValidator : AbstractValidator<AddCommand>
    {
        public AddCommandValidator()
        {
            RuleFor(ac => ac.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .MaximumLength(25);

            RuleFor(ac => ac.Description)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .MaximumLength(250);

            RuleFor(ac => ac.UnitPrice)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(ac => ac.UnitsInStock)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
