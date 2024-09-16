using LkhToolBox.ClientServices.MovieServices;
using LkhToolBox.Contracts.Movies.Requests;
using LkhToolBox.Contracts.Movies.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace LkhToolBox.ClientServices.Movies
{
    public class MovieService : IMovieService
    {
        public async Task<MoviesResponse> GetMovies(GetAllMoviesRequest request)
        {
           HttpClient client = new HttpClient();
            var response =  await client.GetAsync("/movies");
            var movies =await response.Content.ReadFromJsonAsync<MoviesResponse>();
            return movies;
        }
    }
}
