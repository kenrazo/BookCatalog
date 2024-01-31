namespace BookCatalog.Application.BookCatalog
{
    public class BookCatalogResponse
    {
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublishDateUtc { get; set; }
        public string Category { get; set; }
    }

}