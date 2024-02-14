using System.Reflection;
using MediatR;
using FluentValidation;
using Students.Application.Common.Behaviors;
using Microsoft.Extensions.DependencyInjection;

namespace Students.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(
             this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>),
                typeof(ValidationBehavior<,>));
            return services;
        }
    }
}
