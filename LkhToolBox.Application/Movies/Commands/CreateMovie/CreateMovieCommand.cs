using LkhToolBox.Domain.Movies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LkhToolBox.Application.Movies.Commands.CreateMovie
{
    public record CreateMovieCommand(Movie Movie, CancellationToken Token)
        : IRequest<Movie>;

}
