using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace SchoolProject.Core;

public static class ModuleCoreDependncies
{
    public static IServiceCollection AddCoreDependncies(this IServiceCollection services)
    {
        services.AddMediatR(config => config.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        return services;
    }
}
