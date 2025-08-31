using JournalEntry.Infrastructure.InfrastructureBases;
using Microsoft.Extensions.DependencyInjection;

namespace JournalEntry.Infrastructure
{
    public static class ModuleInfrastructureDependencies
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
        {
            services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
            return services;
        }
    }
}
