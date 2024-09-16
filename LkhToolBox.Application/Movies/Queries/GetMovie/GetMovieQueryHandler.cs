using LkhToolBox.Application.Common.Interfaces;
using LkhToolBox.Domain.Movies;
using MediatR;

namespace LkhToolBox.Application.Movies.Queries.GetMovie
{
    public class GetMovieQueryHandler(
        IMovieRepository movieRepository
        )
        : IRequestHandler<GetMovieQuery, Movie?>
    {
        public async Task<Movie?> Handle(GetMovieQuery request, CancellationToken cancellationToken)
        {
            var movie = await movieRepository.GetBySlugAsync(request.Slug, token: cancellationToken);

            return movie;
        }
    }
}
