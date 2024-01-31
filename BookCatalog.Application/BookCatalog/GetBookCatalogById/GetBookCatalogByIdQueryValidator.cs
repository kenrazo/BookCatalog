using FluentValidation;

namespace BookCatalog.Application.BookCatalog.GetBookCatalogById
{
    public sealed class GetBookCatalogByIdQueryValidator : AbstractValidator<GetBookCatalogByIdQuery>
    {
        public GetBookCatalogByIdQueryValidator()
        {
            RuleFor(x => x.Id)
           .Cascade(CascadeMode.StopOnFirstFailure)
           .NotNull().WithMessage("GUID cannot be null")
           .NotEmpty().WithMessage("GUID cannot be empty")
           .When(x => x.Id.HasValue)
           .Must(BeAValidGuid).WithMessage("Invalid GUID format");
        }

        private bool BeAValidGuid(Guid? guid)
        {
            if (!guid.HasValue)
            {
                return true;
            }

            return !Guid.Empty.Equals(guid.Value);
        }
    }
}
