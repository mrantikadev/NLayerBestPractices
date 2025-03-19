using FluentValidation;

namespace App.Services.Categories.Create
{
    public class CreateCategoryRequestValidator : AbstractValidator<CreateCategoryRequest>
    {
        public CreateCategoryRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .Length(3, 20).WithMessage("Name must be between 3 and 20 characters.");
        }
    }
}
