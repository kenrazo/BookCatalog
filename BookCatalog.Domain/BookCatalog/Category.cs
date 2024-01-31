using BookCatalog.Domain.Abstractions;

namespace BookCatalog.Domain.BookCatalog
{
    public class Category : BaseDomainEntity
    {
        public string Name { get; private set; }

        public Category()
        {
        }

        public static Category Create(string name)
        {
            return new Category { Name = name };
        }
    }
}
