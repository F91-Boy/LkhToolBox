using LkhToolBox.Domain.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LkhToolBox.Application.Common.Interfaces
{
    public interface IMovieRepository
    {
        Task AddAsync(Movie movie, CancellationToken token = default);

        Task<Movie?> GetByIdAsync(Guid id, Guid? userId = default, CancellationToken token = default);

        Task<Movie?> GetBySlugAsync(string slug, Guid? userId = default, CancellationToken token = default);


        Task<IEnumerable<Movie>> GetListAsync(GetAllMoviesOptions options, CancellationToken token = default);

        Task UpdateAsync(Movie movie, CancellationToken token = default);

        Task DeleteAsync(Movie movie, CancellationToken token = default);

        Task<bool> ExistsByIdAsync(Guid id, CancellationToken token = default);
    }
}
