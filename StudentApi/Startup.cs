using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Serilog;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Student.Repository;
using Student.Service;
using Microsoft.EntityFrameworkCore;
using GR.Service.Interface;
using GR.Repository.Interface;
using GR.Repository;
using Student.Repository.Interface;
using Student.Service.Interface;
using StudentApi.Logging;
using Microsoft.Extensions.Logging;
using Serilog.Events;
using AutoMapper;
using StudentApi.Configuration;
using Swashbuckle.AspNetCore.Swagger;
using FluentValidation;
using Student.Data;

namespace StudentApi
{
    public class Startup
    {
        public Startup(IHostingEnvironment env) //IConfiguration configuration
        {

            //Create Configuration 
            var builder = new ConfigurationBuilder()
               .SetBasePath(env.ContentRootPath)
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
               .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
            Environment = env;


            //create 
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Debug)
                .Enrich.FromLogContext()
                .Enrich.WithMachineName()
                .Enrich.WithEnvironmentUserName()
                .WriteTo.RollingFile(@"logs/files-api.log", outputTemplate:
                    "{Timestamp:yyyy-MM-dd HH:mm:ss} {MachineName} [{Level}] {Message}{NewLine}{Exception}")
                //.WriteTo.ColoredConsole(outputTemplate:
                //    "{Timestamp:yyyy-MM-dd HH:mm:ss} {MachineName} [{Level}] {Message}{NewLine}{Exception}")
                .CreateLogger();
        }

        //public IConfiguration Configuration { get; }
        public IConfigurationRoot Configuration { get; }
        public IHostingEnvironment Environment { get; }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Configure Localization
            services.AddLocalization(options => options.ResourcesPath = "Resources");
            services.Configure<RequestLocalizationOptions>(options =>
            {
                var cultureInfoList = new List<CultureInfo>
                {
                    new CultureInfo("en"),
                    new CultureInfo("ar")
                };
                options.DefaultRequestCulture = new RequestCulture("ar", "ar");
                options.SupportedCultures = cultureInfoList;
                options.SupportedUICultures = cultureInfoList;
            });

            //Configure Database connections

            // ConfigureConnectionOptions.ConfigureService(services, Configuration);

            //Use a MS SQL Server database
            // var sqlConnectionString = Configuration.GetConnectionString("StudentSqlDB");

            // // services.AddDbContextPool<StudentDBContext>(options =>
            // services.AddDbContext<StudentDBContext>(options =>
            //    options.UseSqlServer(
            //        sqlConnectionString,
            //        b => b.MigrationsAssembly("StudentApi")
            //    )
            //);

            //Configure Database Context
            ConfigureContext.ConfigureService(services, Configuration);

            //Configure Student Container
            ConfigureStudentContainer.ConfigureService(services, Configuration);
            //Configure Student Aysnc Container
            ConfigureStudentContainerAsync.ConfigureService(services, Configuration);

            //services.AddLogging((builder) => builder.SetMinimumLevel(LogLevel.Trace));

            //.AddFluentValidation();
            //.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Startup>());
            //services.AddScoped<IStudentGeneralService, StudentGeneralService>();
            //services.AddScoped<IStudentGeneralServiceAsync, StudentGeneralServiceAsync>();

            //services.AddScoped<IUnitOfWork, UnitOfWork<StudentDBContext>>();

            //services.AddScoped<IEntityReadStudentGeneralRepository, EntityReadStudentGeneralRepository>();
            //services.AddScoped<IEntityStudentGeneralRepository, EntityStudentGeneralRepository>();

            //services.AddScoped<IEntityReadStudentGeneralRepositoryAsync, EntityReadStudentGeneralRepositoryAsync>();
            //services.AddScoped<IEntityStudentGeneralRepositoryAsync, EntityStudentGeneralRepositoryAsync>();

            //add fluent validation scope
            services.AddScoped<IValidator<StudentGeneralModel> , StudentGeneralModelValidator>();

            //Add MVC To Service
            services.AddMvc();

            //Add Swagger To Service
            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new Info { Title = "Student API", Version = "v1" });
            //});

            //Add Auto Mapper
            services.AddAutoMapper();

            //services.AddScoped<LoggingActionFilter>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {

            //loggerFactory.AddDebug(LogLevel.Trace);
            loggerFactory.AddSerilog(dispose: true);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            
        }
    }
}
