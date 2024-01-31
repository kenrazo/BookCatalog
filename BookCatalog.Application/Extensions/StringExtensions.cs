namespace BookCatalog.Application.Extensions
{
    public static class StringExtensions
    {
        private const string UTCFormatWithoutTime = "yyyy-MM-ddT00:00:00Z";

        public static DateTime ToUtcDateTime(this string data)
        {
            var isValidDateTime = DateTime.TryParse(data, out var newValue);

            return isValidDateTime ? newValue : DateTime.UtcNow;
        }
    }
}
