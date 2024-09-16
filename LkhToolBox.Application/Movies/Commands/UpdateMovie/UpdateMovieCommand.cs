using LkhToolBox.Domain.Movies;
using MediatR;

namespace LkhToolBox.Application.Movies.Commands.UpdateMovie
{
    public record UpdateMovieCommand(Guid Id,Movie Movie):IRequest<Movie?>;

}
