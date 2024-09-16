using AutoMapper;
using LkhToolBox.Api.Auth;
using LkhToolBox.Application;
using LkhToolBox.Application.Movies.Commands.CreateMovie;
using LkhToolBox.Application.Movies.Queries.GetMovie;
using LkhToolBox.Application.Movies.Queries.GetMovieList;
using LkhToolBox.Contracts.Movies.Requests;
using LkhToolBox.Contracts.Movies.Responses;
using LkhToolBox.Domain.Movies;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace LkhToolBox.Api.Controllers
{
    [ApiController]
    public class MoviesController(
        IMediator mediator ,
        //IOutputCacheStore outputCacheStore,
        IMapper mapper
        ) : ControllerBase
    {
        //[ServiceFilter(typeof(ApiKeyAuthFilter))]
        //[Authorize(AuthConstants.TrustedMemberPolicyName)]
        [HttpPost(ApiEndpoints.Movies.Create)]
        [ProducesResponseType(typeof(MovieResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(MovieResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateMovieRequest request, CancellationToken token)
        {
            var movie =mapper.Map<CreateMovieRequest,Movie>(request);

            var command = new CreateMovieCommand(movie,token);

            var createResult =  await mediator.Send(command, token);

            //await outputCacheStore.EvictByTagAsync("movies", token);//令缓存失效

            //var response = mapper.Map<Movie, MovieResponse>(createResult.Data);
            ////return CreatedAtAction(nameof(Get), new { idOrSlug = movie.Id }, response);
            //return CreatedAtAction("", new { idOrSlug = movie.Id }, response);
            return Ok(createResult);
        }

        [HttpGet(ApiEndpoints.Movies.Get)]
        //[OutputCache(PolicyName = "MovieCache")]
        //[ResponseCache(Duration =30,VaryByHeader = "Accept,Accept-Encoding",Location = ResponseCacheLocation.Any)]
        [ProducesResponseType(typeof(MovieResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get([FromRoute] string idOrSlug, CancellationToken token)
        {
            //var userId = HttpContext.GetUserId();

            //var movie = Guid.TryParse(idOrSlug, out var id)
            //    ? await mediator.GetByIdAsync(id, userId, token)
            //    : await mediator.GetBySlugAsync(idOrSlug, userId, token);

            //if (movie is null)
            //{
            //    return NotFound();
            //}

            //var response = movie.MapToResponse();

            var query = new GetMovieQuery(idOrSlug);

            var queryResult = await mediator.Send(query, token);
            return Ok(queryResult);
        }

        [HttpGet(ApiEndpoints.Movies.GetAll)]
        //[OutputCache(PolicyName = "MovieCache")]
        //[ResponseCache(Duration = 30, VaryByQueryKeys = ["title","yearOfRelease","sortBy","page","pageSize"],VaryByHeader = "Accept,Accept-Encoding", Location = ResponseCacheLocation.Any)]
        [ProducesResponseType(typeof(MovieResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll([FromQuery] GetAllMoviesRequest request, CancellationToken token)
        {
            //var userId = HttpContext.GetUserId();

            var option = mapper.Map<GetAllMoviesRequest, GetAllMoviesOptions>(request);
            var query = new GetMovieListQuery(option);
            var queryResult = await mediator.Send(query, token);
           
            return Ok(queryResult);
        }

        //[Authorize(AuthConstants.TrustedMemberPolicyName)]
        //[HttpPut(ApiEndpoints.Movies.Update)]
        //[ProducesResponseType(typeof(MovieResponse), StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(typeof(ValidationFailureResponse), StatusCodes.Status400BadRequest)]
        //public async Task<IActionResult> Update([FromRoute] Guid id, [
        //    FromBody]UpdateMovieRequest request, CancellationToken token)
        //{
        //    var userId = HttpContext.GetUserId();

        //    var movie = request.MapToMovie(id);
        //    var updatedMovie = await mediator.UpdateAsync(movie, userId, token);
        //    if (updatedMovie is null)
        //    {
        //        return NotFound();
        //    }


        //    var response = movie.MapToResponse();

        //    await outputCacheStore.EvictByTagAsync("movies", token);//令缓存失效
        //    return Ok(response);
        //}

        //[Authorize(AuthConstants.AdminUserPolicyName)]
        //[HttpDelete(ApiEndpoints.Movies.Delete)]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken token)
        //{
        //    var userId = HttpContext.GetUserId();

        //    var deleted = await mediator.DeleteByIdAsync(id, token);
        //    if (!deleted)
        //    {
        //        return NotFound();
        //    }

        //    await outputCacheStore.EvictByTagAsync("movies", token);//令缓存失效
        //    return Ok();
        //}
    }
}
