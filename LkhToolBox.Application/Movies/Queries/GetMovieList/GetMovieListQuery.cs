using LkhToolBox.Domain.Movies;
using MediatR;

namespace LkhToolBox.Application.Movies.Queries.GetMovieList
{
    public record GetMovieListQuery(GetAllMoviesOptions Options)
        : IRequest<List<Movie>>;
   
}
