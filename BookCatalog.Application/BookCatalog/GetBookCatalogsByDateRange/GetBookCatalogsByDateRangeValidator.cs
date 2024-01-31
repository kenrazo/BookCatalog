using FluentValidation;
using System.Globalization;

namespace BookCatalog.Application.BookCatalog.GetBookCatalogsByDateRange
{
    public class GetBookCatalogsByDateRangeValidator : AbstractValidator<GetBookCatalogsByDateRangeQuery>
    {
        public GetBookCatalogsByDateRangeValidator()
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

            RuleFor(model => model.StartDate)
                .NotEmpty().WithMessage("Start date is required.")
                .Must(BeValidDate).WithMessage("Invalid start date format.");

            RuleFor(model => model.EndDate)
                .NotEmpty().WithMessage("End date is required.")
                .Must(BeValidDate).WithMessage("Invalid end date format.")
                .GreaterThanOrEqualTo(model => model.StartDate).WithMessage("End date must be greater than or equal to the start date.");

            RuleFor(model => model)
                .Custom((model, context) =>
                {
                    if (!string.IsNullOrEmpty(model.StartDate) && !string.IsNullOrEmpty(model.EndDate))
                    {
                        var startDate = DateTime.ParseExact(model.StartDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                        var endDate = DateTime.ParseExact(model.EndDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);

                        if (startDate > endDate)
                        {
                            context.AddFailure("Start date cannot be greater than end date.");
                        }

                        if ((endDate - startDate).TotalDays > 30)
                        {
                            context.AddFailure("Date range cannot be greater than 30 days.");
                        }
                    }
                });
        }

        private bool BeValidDate(string date)
        {
            return DateTime.TryParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out _);
        }
    }
}

