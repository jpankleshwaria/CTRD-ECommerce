using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Swashbuckle.AspNetCore.Swagger;
using Administration.IOC;
using Common.Domain.Constants;
using CTRD.ECommerce.Api.Exceptions;
using CTRD.ECommerce.Api.Filters;
using CTRD.ECommerce.Api.Interfaces;
using CTRD.ECommerce.Api.Helper;

namespace CTRD.ECommerce
{
    /// <summary>
    /// The Startup Class: Configures services and the app's request pipeline
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <value>
        /// The configuration.
        /// </value>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Configures the services. 
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services">The services.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddControllers();
            services.AddMemoryCache();
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(HttpGlobalExceptionFilter));
                options.Filters.Add(typeof(SetUserInfoToRequestParamFilter));
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSingleton<IHttpClientAccessor, DefaultHttpClientAccessor>();
            
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
           .AddJwtBearer(options =>
           {
               options.Authority = Configuration["auth:bearer:authority"];
               options.Audience = Configuration["auth:bearer:audience"];
               options.RequireHttpsMetadata = false;
               options.SaveToken = true;
               options.TokenValidationParameters.RoleClaimType = "role";
               options.TokenValidationParameters.NameClaimType = "name";
           });

            services.AddHttpContextAccessor();
            services.AddHttpClient();

            //Register IOC Services
            AdminBootStrapper.RegisterServices(services);

            //Initialize Database Connection String
            Constants.CspDbConnectionString = Configuration.GetConnectionString("CspDbConnectionString");

            services.AddHttpContextAccessor();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "CTRD.ECommerce Administration API", Version = "v1" });
                c.IncludeXmlComments(
                    string.Format(@"{0}CTRD.ECommerce.Api.xml", AppDomain.CurrentDomain.BaseDirectory)
                    , false);
                c.IncludeXmlComments(
                    string.Format(@"{0}CTRD.ECommerce.Application.xml", AppDomain.CurrentDomain.BaseDirectory)
                    , false);
            });
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline. 
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CTRD.ECommerce Administration API V1");
            });

            app.UseMvc();

            //app.UseHttpsRedirection();

            //app.UseRouting();

            //app.UseAuthorization();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});
        }
    }
}
