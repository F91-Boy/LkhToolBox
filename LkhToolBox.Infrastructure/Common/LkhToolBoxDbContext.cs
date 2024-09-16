using LkhToolBox.Application.Common.Interfaces;
using LkhToolBox.Domain.Movies;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace LkhToolBox.Infrastructure.Common
{
    public class LkhToolBoxDbContext : DbContext, IUnitOfWork
    {
        public DbSet<Movie> Movies { get; set; } = null!;
        public DbSet<MovieRating> MovieRatings { get; set; } = null!;

        public LkhToolBoxDbContext(DbContextOptions<LkhToolBoxDbContext> options) : base(options)
        {
        }

        public async Task CommitChangesAsync()
        {
            await SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
