using FluentValidation;

namespace BookCatalog.Application.BookCatalog.GetBookCatalogs
{
    public class GetBookCatalogsQueryValidator : AbstractValidator<GetBookCatalogsQuery>
    {
        public GetBookCatalogsQueryValidator()
        {
            RuleFor(m => m.PageNumber)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(m => m.ItemsPerPage)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0)
                .LessThanOrEqualTo(100);

        }
    }
}
