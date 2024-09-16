using LkhToolBox.Domain.Movies;
using MediatR;

namespace LkhToolBox.Application.Movies.Queries.GetMovie
{
    public record GetMovieQuery(string Slug) : IRequest<Movie?>;
   
}
