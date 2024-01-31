namespace BookCatalog.Domain.Abstractions
{
    public class PaginationResult<T> where T : BaseDomainEntity
    {
        public int PageNumber { get; set; }
        public int ItemsPerPage { get; set; }
        public int TotalRecords { get; set; }
        public int NumberOfPages { get; set; }
        public List<T> Datas { get; set; }
    }
}
