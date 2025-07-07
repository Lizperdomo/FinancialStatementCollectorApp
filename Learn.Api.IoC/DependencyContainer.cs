using Microsoft.Extensions.DependencyInjection;
using Learn.Api.Repository.EFCore;
using Learn.Api.UseCases;
using Learn.Api.Controllers;

namespace Learn.Api.IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddLearnServices(this IServiceCollection services)
        {
            services.AddLearnUseCases();
            services.AddLearnControllers();
            services.AddLearnRepositories();
            return services;
        }
    }
}
