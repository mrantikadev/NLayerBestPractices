using FluentValidation;

namespace App.Services.Products.Update
{
    public class UpdateProductRequestValidator : AbstractValidator<UpdateProductRequest>
    {
        public UpdateProductRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .Length(3, 20).WithMessage("Name must be between 3 and 20 characters.");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be greater than 0.");

            RuleFor(x => x.Stock)
                .InclusiveBetween(1, 100).WithMessage("Stock must be between 1 and 100.");
        }
    }
}
