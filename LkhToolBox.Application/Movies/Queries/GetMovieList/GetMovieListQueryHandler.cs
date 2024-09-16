using LkhToolBox.Application.Common.Interfaces;
using LkhToolBox.Domain.Movies;
using MediatR;

namespace LkhToolBox.Application.Movies.Queries.GetMovieList
{
    public class GetMovieListQueryHandler(
        IMovieRepository movieRepository
        ) :
        IRequestHandler<GetMovieListQuery, List<Movie>>
    {
        public async Task<List<Movie>> Handle(GetMovieListQuery request, CancellationToken cancellationToken)
        {
            var movieList  =(await movieRepository.GetListAsync(request.Options, cancellationToken)).ToList();
            return movieList;
        }
    }
}
