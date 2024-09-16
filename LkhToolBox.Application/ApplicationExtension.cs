using Microsoft.Extensions.DependencyInjection;

namespace LkhToolBox.Application
{
    public static class ApplicationExtension
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(options =>
            {
                options.RegisterServicesFromAssemblyContaining(typeof(ApplicationExtension));
            });

            return services;
        }

    }
}
