using LkhToolBox.Application.Common.Interfaces;
using LkhToolBox.Domain.Movies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
