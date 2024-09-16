using LkhToolBox.Domain.Movies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LkhToolBox.Application.Movies.Commands.DeleteMovie
{
    public record DeleteMovieCommand(Guid Id):IRequest<bool>;
    
}
