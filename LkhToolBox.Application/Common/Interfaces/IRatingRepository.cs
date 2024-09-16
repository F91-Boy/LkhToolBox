using LkhToolBox.Domain.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LkhToolBox.Application.Common.Interfaces
{
    public interface IRatingRepository
    {
        Task<bool> RateMovieAsync(Guid movieId, int rating, Guid userId, CancellationToken token = default);

        Task<bool> DeleteRatingAsync(Guid movieId, Guid userId, CancellationToken token = default);

        Task<IEnumerable<MovieRating>> GetRatingsForUserAsync(Guid userId, CancellationToken token = default);
    }
}
