namespace BookCatalog.Domain.Exceptions
{
    public sealed record ValidationError(string PropertyName, string ErrorMessage);
}
