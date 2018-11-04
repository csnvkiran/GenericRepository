using GR.Repository;
using GR.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Student.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace StudentApi.Configuration
{
    public static class ConfigureContext
    {
        /// <summary>
        /// Configures the service.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="configuration">The configuration.</param>
        public static void ConfigureService(IServiceCollection services, IConfigurationRoot configuration)
        {
            //ConnectionSettings conn = configuration.GetSection("ConnectionStrings");
            IConfigurationSection sectionData = configuration.GetSection("ConnectionStrings");
            var conn = new ConnectionSettings();
            sectionData.Bind(conn);

            // //Use a MS SQL Server database
            // var sqlConnectionString = conn.StudentSqlDB; //Configuration.GetConnectionString("StudentSqlDB")

            // // services.AddDbContextPool<StudentDBContext>(options =>
            // services.AddDbContext<StudentDBContext>(options =>
            //    options.UseSqlServer(
            //        sqlConnectionString,
            //        b => b.MigrationsAssembly("StudentApi")
            //    )
            //);


            //Use a My SQL Server database
            var sqlConnectionString = conn.StudentMySqlDB; //Configuration.GetConnectionString("StudentSqlDB")

            // services.AddDbContextPool<StudentDBContext>(options =>
            services.AddDbContext<StudentDBContext>(options =>
               options.UseMySQL(
                   sqlConnectionString,
                   b => b.MigrationsAssembly("StudentApi")
               )
           );


            services.AddScoped<IUnitOfWork, UnitOfWork<StudentDBContext>>();
            services.AddScoped<IUnitOfWorkAsync, UnitOfWorkAsync<StudentDBContext>>();

        }
    }
}
