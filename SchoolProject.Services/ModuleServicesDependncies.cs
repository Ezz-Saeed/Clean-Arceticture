using Microsoft.Extensions.DependencyInjection;

namespace SchoolProject.Services;

public static class ModuleServicesDependncies
{
    public static IServiceCollection AddServicesDependncies(this IServiceCollection services)
    {
        services.AddTransient<IStudentService, StudentService>();
        return services;
    }
}
