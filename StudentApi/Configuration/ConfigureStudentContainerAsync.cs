using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Student.Repository;
using Student.Repository.Interface;
using Student.Service;
using Student.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentApi.Configuration
{
    //
    public static class ConfigureStudentContainerAsync
    {
        /// <summary>
        /// Configures the service.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="configuration">The configuration.</param>
        public static void ConfigureService(IServiceCollection services, IConfigurationRoot configuration)
        {
            //Read Repository
            services.AddScoped<IEntityReadStudentGeneralRepositoryAsync, EntityReadStudentGeneralRepositoryAsync>();

            //Create - Update - Delete Repository
            services.AddScoped<IEntityStudentGeneralRepositoryAsync, EntityStudentGeneralRepositoryAsync>();

            //Service Repository
            services.AddScoped<IStudentGeneralServiceAsync, StudentGeneralServiceAsync>();
        }
    }
}
