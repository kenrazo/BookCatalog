using BookCatalog.Application.Abstractions.Behaviors;
using BookCatalog.Application.MappingProfiles;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BookCatalog.Application.DependencyInjections
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(BookCategoryProfile).GetTypeInfo().Assembly);

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(m =>
            {
                m.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));


            return services;
        }
    }
}
