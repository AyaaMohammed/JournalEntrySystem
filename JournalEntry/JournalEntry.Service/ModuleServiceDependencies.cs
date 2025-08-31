using DinkToPdf;
using DinkToPdf.Contracts;
using JournalEntry.Infrastructure.Abstracts;
using JournalEntry.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace JournalEntry.Service
{
    public static class ModuleServiceDependencies
    {
        public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
        {
            // Register other service layer dependencies here if needed
            services.AddTransient<IJournalRepository,JournalRepository>();
            services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));

            return services;
        }
    }
}
