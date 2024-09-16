using LkhToolBox.Domain.Movies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LkhToolBox.Application.Movies.Queries.GetMovieList
{
    public record GetMovieListQuery(GetAllMoviesOptions Options)
        : IRequest<ResponseResult<List<Movie>>>;
   
}
