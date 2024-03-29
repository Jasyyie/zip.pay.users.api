using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore;
using System.IO;
using Microsoft.AspNetCore.StaticFiles;
using System.Reflection;
using Microsoft.OpenApi;
using Zip.Pay.Users.Service.Services;
using Zip.Pay.Users.Model;
using Zip.Pay.Users.Repository;
using Microsoft.OpenApi.Models;
using Zip.Pay.Users.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Zip.Pay.Users.Repository.Repositories;
using Newtonsoft.Json.Serialization;
using FluentValidation.AspNetCore;
using FluentValidation;


namespace Zip.Pay.Users.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers()
            .AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver =
                    new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "ZipPay| Users",
                    Version = "v1",
                    Description = "",
                    Contact = new OpenApiContact { Name = "Jasmine Kaur", Email = "jaskhundal@gmail.com" }
                });

                // Set the comments path for the Swagger JSON and UI.
                var basePath = AppContext.BaseDirectory;
                var xmlPath = Path.Combine(basePath, "Zip.Pay.Users.Api.xml");
                c.IncludeXmlComments(xmlPath);
            });

            // IOC setup
            services
             .AddDbContext<ZipPayUserDbContext>(options =>
               {
                   options.UseSqlServer(Configuration.GetSection("ZipPayUserDatabase:ConnectionString").Value);
               });

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IUserService, UserService>();
            services.AddTransient<IValidator<User>, UserValidator>();
            services.AddControllers();
            services.AddMvc().AddFluentValidation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
