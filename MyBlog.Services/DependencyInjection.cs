using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MyBlog.Services.Common;
using System;
using System.Reflection;

namespace MyBlog.Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            return services;
        }
    }
}
