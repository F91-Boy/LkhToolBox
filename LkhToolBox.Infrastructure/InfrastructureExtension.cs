using LkhToolBox.Application.Common.Interfaces;
using LkhToolBox.Infrastructure.Common;
using LkhToolBox.Infrastructure.Movies.Presistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LkhToolBox.Infrastructure
{
    public static class InfrastructureExtension
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, 
            string dbConnectionString = "")
        {
            return services
                .AddPersistence(dbConnectionString);
        }

        public static IServiceCollection AddPersistence(this IServiceCollection services,
            string dbConnectionString)
        {
            services.AddDbContext<LkhToolBoxDbContext>(options =>
                options.UseSqlServer(dbConnectionString));

            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IUnitOfWork>(serviceProvider => serviceProvider.GetRequiredService<LkhToolBoxDbContext>());

            return services;
        }
    }
}
