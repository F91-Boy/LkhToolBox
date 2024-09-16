using LkhToolBox.Application.Common.Interfaces;
using LkhToolBox.Domain.Movies;
using LkhToolBox.Infrastructure.Common;
using Microsoft.EntityFrameworkCore;

namespace LkhToolBox.Infrastructure.Movies.Presistence
{
    public class MovieRepository(LkhToolBoxDbContext dbContext) : IMovieRepository
    {
        //添加
        public async Task AddAsync(Movie movie, CancellationToken token = default)
        {
            await dbContext.Movies.AddAsync(movie, token);
        }

        //删除
        public Task DeleteAsync(Movie movie, CancellationToken token = default)
        {
            dbContext.Movies.Remove(movie);
            return Task.CompletedTask;
        }

        //判断存在
        public async Task<bool> ExistsByIdAsync(Guid id, CancellationToken token = default)
        {
            return await dbContext.Movies.AnyAsync(m => m.Id == id, token);
        }

        //通过id获取
        public async Task<Movie?> GetByIdAsync(Guid id, Guid? userId = null, CancellationToken token = default)
        {
            return await dbContext.Movies.FirstOrDefaultAsync(m => m.Id == id, token);
        }

        //通过slug获取
        public async Task<Movie?> GetBySlugAsync(string slug, Guid? userId = null, CancellationToken token = default)
        {
            return await dbContext.Movies.FirstOrDefaultAsync(m => m.Slug == slug, token);
        }

        //获取符合条件的列表
        public async Task<IEnumerable<Movie>> GetListAsync(GetAllMoviesOptions options, CancellationToken token = default)
        {
            IOrderedQueryable<Movie> orderResult = null!;

            var movieIQuery = dbContext.Movies.AsQueryable();

            if (options.SortField != SortFieldEnum.DefaultSort)
            {
                if (options.SortField == SortFieldEnum.Title)
                {
                    orderResult = options.SortOrder switch
                    {
                        SortOrderEnum.Asc => movieIQuery.OrderBy(m => m.Title),
                        SortOrderEnum.Desc => movieIQuery.OrderByDescending(m => m.Title),
                    };
                }else if (options.SortField == SortFieldEnum.Year)
                {
                    orderResult = options.SortOrder switch
                    {
                        SortOrderEnum.Asc => movieIQuery.OrderBy(m => m.YearOfRelease),
                        SortOrderEnum.Desc => movieIQuery.OrderByDescending(m => m.YearOfRelease),
                    };
                }
                movieIQuery = orderResult.AsQueryable();
                
            }

            if (options.YearOfRelease != null)
            {
                movieIQuery = movieIQuery.Where(m => m.YearOfRelease == options.YearOfRelease);
            }

            if (options.Title != null)
            {
                movieIQuery = movieIQuery.Where(m => m.Title.Contains(options.Title));
            }
            return await movieIQuery
                .Skip((options.Page-1) * options.PageSize).Take(options.PageSize).ToListAsync();
        }

        //更新
        public Task UpdateAsync(Movie movie, CancellationToken token = default)
        {
            dbContext.Movies.Update(movie);
            return Task.CompletedTask;
        }
    }
}
