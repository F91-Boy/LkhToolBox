using LkhToolBox.Contracts.Movies.Requests;
using LkhToolBox.Contracts.Movies.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LkhToolBox.ClientServices.MovieServices
{
    public interface IMovieService
    {
        Task<MoviesResponse> GetMovies(GetAllMoviesRequest request);
    }
}
