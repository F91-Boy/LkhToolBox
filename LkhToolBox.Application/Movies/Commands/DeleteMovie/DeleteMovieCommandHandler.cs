using LkhToolBox.Application.Common.Interfaces;
using MediatR;

namespace LkhToolBox.Application.Movies.Commands.DeleteMovie
{
    public class DeleteMovieCommandHandler (
        IMovieRepository movieRepository,
        IUnitOfWork unitOfWork
        )
        : IRequestHandler<DeleteMovieCommand, bool>
    {
        public async Task<bool> Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
        {
            var movie  = await movieRepository.GetByIdAsync( request.Id );
            if (movie == null)
            {
                return false;
            }
            await movieRepository.DeleteAsync(movie);
            await unitOfWork.CommitChangesAsync();

            return true;   
        }
    }
}
