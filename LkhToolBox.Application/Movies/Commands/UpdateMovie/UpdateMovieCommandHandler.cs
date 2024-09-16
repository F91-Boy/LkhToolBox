using LkhToolBox.Application.Common.Interfaces;
using LkhToolBox.Domain.Movies;
using MediatR;

namespace LkhToolBox.Application.Movies.Commands.UpdateMovie
{
    public class UpdateMovieCommandHandler(
          IMovieRepository movieRepository,
        IUnitOfWork unitOfWork
        ) : IRequestHandler<UpdateMovieCommand, Movie?>
    {
        public async Task<Movie?> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
        {
            var movie = await movieRepository.GetByIdAsync(request.Id);
            if (movie == null) return movie;

            await movieRepository.UpdateAsync(movie);
            await unitOfWork.CommitChangesAsync();

            request.Movie.Id = movie.Id;
            request.Movie.Slug = request.Movie.GenerateSlug();
            return request.Movie;
        }
    }
}
