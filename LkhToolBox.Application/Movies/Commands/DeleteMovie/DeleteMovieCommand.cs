using MediatR;

namespace LkhToolBox.Application.Movies.Commands.DeleteMovie
{
    public record DeleteMovieCommand(Guid Id):IRequest<bool>;
    
}
