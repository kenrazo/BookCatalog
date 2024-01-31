namespace BookCatalog.Application.BookCatalog
{
    public class BaseBookCatalogResponsePagination
    {
        public int PageNumber { get; set; }
        public int ItemsPerPage { get; set; }
        public int TotalRecords { get; set; }
        public int NumberOfPages { get; set; }
        public List<BookCatalogResponse> BookCatalogs { get; set; }
    }

}
