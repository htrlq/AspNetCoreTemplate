using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Core.Template.Filter;
using Core.Template.Middleware._Exception;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace Core.Template
{
    /// <summary>
    /// Startup
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Generate
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Configuration
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Configure Services
        /// </summary>
        /// <param name="services"></param>
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region Add Exception Handler
            services.AddExceptionHandler();
            #endregion

            #region Add Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Core.Template api Mangger",
                    Description = "Core.Template RESTfull api Mangger",
                    TermsOfService = "None",
                    Contact = new Contact { Name = "NCoreCoder", Email = "2598145226@qq.com", Url = "https://www.cnblogs.com/NCoreCoder/" }
                });

                //Set the comments path for the swagger json and ui.
                var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                var xmlPath = Path.Combine(basePath, "Core.Template.xml");

                c.IncludeXmlComments(xmlPath);
            });
            #endregion

            services.AddMvc(options=> {
                //options.Filters.Add<GoldModelFilter>();
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        /// <summary>
        /// Configure
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            #region Use Swagger
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Core.Template API V1");
                c.ShowExtensions();
            });
            #endregion

            #region Use Exception Handler
            app.UseExceptionMiddleware();
            #endregion

            app.UseMvc();
        }
    }
}
