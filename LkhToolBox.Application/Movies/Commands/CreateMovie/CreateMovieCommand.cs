using LkhToolBox.Domain.Movies;
using MediatR;

namespace LkhToolBox.Application.Movies.Commands.CreateMovie
{
    public record CreateMovieCommand(Movie Movie, CancellationToken Token)
        : IRequest<Movie>;

}
