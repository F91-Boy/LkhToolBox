namespace LkhToolBox.Domain.Movies
{
    public class GetAllMoviesOptions
    {
        public string? Title { get; set; }

        public int? YearOfRelease { get; set; }

        public Guid? UserId { get; set; }

        public SortFieldEnum? SortField { get; set; }

        public SortOrderEnum? SortOrder { get; set; }

        public int Page { get; set; }

        public int PageSize { get; set; }
    }
}
