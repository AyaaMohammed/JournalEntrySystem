using FluentValidation;
using JournalEntry.Core.Behaviors;
using JournalEntry.Infrastructure.Abstracts;
using JournalEntry.Service.Abstracts;
using JournalEntry.Service.Implementation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace JournalEntry.Core
{
    public static class ModuleCoreDependencies
    {
        public static IServiceCollection AddCoreDependencies(this IServiceCollection services)
        {
            // Configure AutoMapper
            services.AddAutoMapper(cfg => cfg.AddMaps(typeof(ModuleCoreDependencies).Assembly));

            // Register MediatR
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ModuleCoreDependencies).Assembly));

            // Register FluentValidation Validators from current Assembly
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            // Register Pipeline Behavior for Validation
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            // You can register other core services here as needed
            services.AddTransient<IJournalService, JournalService>();

            return services;
        }
    }
}
