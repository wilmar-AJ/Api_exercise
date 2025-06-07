using Api_exercise.Entities;
using FluentValidation;

namespace Api_exercise.Validators;

public class ProductsEntitiesValidator : AbstractValidator<ProductsEntities>
{
    public ProductsEntitiesValidator()
    {
        RuleFor(p => p.Id)
            .NotEmpty().WithMessage("El ID es obligatorio");

        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("El nombre es obligatorio");

        RuleFor(p => p.Image)
            .NotEmpty().WithMessage("La imagen es obligatoria");
    }
}
