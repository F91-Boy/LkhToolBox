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
        : IRequestHandler<GetMovieQuery, ResponseResult<Movie>>
    {
        public async Task<ResponseResult<Movie>> Handle(GetMovieQuery request, CancellationToken cancellationToken)
        {
            var movie = await movieRepository.GetBySlugAsync(request.Slug, token: cancellationToken);

            return movie == null ?
                 new ResponseResult<Movie>
                 {
                     IsSuccess = false,
                     ErrorMessage = "不存在这样的电影"
                 } :
                 new ResponseResult<Movie>
                 {
                     Data = movie
                 };
        }
    }
}
