using LkhToolBox.Domain.Movies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LkhToolBox.Application.Movies.Commands.UpdateMovie
{
    public record UpdateMovieCommand(Guid Id,Movie Movie):IRequest<Movie?>;

}
