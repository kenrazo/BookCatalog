using BookCatalog.Domain.Abstractions;

namespace BookCatalog.Domain.BookCatalog
{
    public class Book : BaseDomainEntity
    {
        public Guid CategoryId { get; private set; }
        public Category Category { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime PublishDateUtc { get; private set; }

        public Book()
        {
        }

        public static Book Create(Guid categoryId, string title, string descriptiom,
            DateTime publishDateUtc)
        {
            return new()
            {
                CategoryId = categoryId,
                Title = title,
                Description = descriptiom,
                PublishDateUtc = publishDateUtc
            };
        }
    }
}
