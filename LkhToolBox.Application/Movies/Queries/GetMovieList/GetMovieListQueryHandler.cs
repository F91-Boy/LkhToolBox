using LkhToolBox.Application.Common.Interfaces;
using LkhToolBox.Domain.Movies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LkhToolBox.Application.Movies.Queries.GetMovieList
{
    public class GetMovieListQueryHandler(
        IMovieRepository movieRepository
        ) :
        IRequestHandler<GetMovieListQuery, ResponseResult<List<Movie>>>
    {
        public async Task<ResponseResult<List<Movie>>> Handle(GetMovieListQuery request, CancellationToken cancellationToken)
        {
            var movieList  =(await movieRepository.GetListAsync(request.Options, cancellationToken)).ToList();
            return new ResponseResult<List<Movie>>
            {
                Data = movieList
            };
        }
    }
}
