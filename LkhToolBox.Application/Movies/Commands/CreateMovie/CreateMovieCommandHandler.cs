using LkhToolBox.Application.Common.Interfaces;
using LkhToolBox.Domain.Movies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LkhToolBox.Application.Movies.Commands.CreateMovie
{
    public class CreateMovieCommandHandler(
        IMovieRepository movieRepository,
        IUnitOfWork unitOfWork
        )
        : IRequestHandler<CreateMovieCommand, Movie>
    {
        public async Task<Movie> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
        {
            request.Movie.Slug = request.Movie.GenerateSlug();
            await movieRepository.AddAsync(request.Movie, cancellationToken);
            await unitOfWork.CommitChangesAsync();
            return request.Movie;
        }
    }
}
