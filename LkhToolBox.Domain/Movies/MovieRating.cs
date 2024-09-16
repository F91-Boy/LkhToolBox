namespace LkhToolBox.Domain.Movies
{
    public class MovieRating
    {
        public required Guid Id { get; set; }

        public required Guid MovieId { get; init; }

        public required string Slug { get; init; }

        public required int Rating { get; init; }
    }
}
