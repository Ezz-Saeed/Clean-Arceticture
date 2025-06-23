using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace SchoolProject.Infrastructure
{
    public static class ModuleInfrastructureDependncies
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddTransient<IStudentRepository, StudentRepository>();
            return services;
        }
    }
}
