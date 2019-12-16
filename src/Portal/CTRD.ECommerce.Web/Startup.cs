using System.Linq;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using CTRD.ECommerce.Web.AutomaticTokenManagement;
using CTRD.ECommerce.Web.Helper;
using CTRD.ECommerce.Web.Interfaces;

namespace CTRD.ECommerce.Web
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            })
            .AddCookie(options =>
            {
                options.Cookie.SameSite = SameSiteMode.None;
            })
            .AddAutomaticTokenManagement()
            .AddOpenIdConnect(options =>
            {
                options.Authority = Configuration["auth:oidc:authority"];
                options.RequireHttpsMetadata = false;
                options.ResponseType = "code"; //refers to OpenIdConnect Authorization Code
                options.SaveTokens = true;
                options.GetClaimsFromUserInfoEndpoint = true;
                options.ClientId = Configuration["auth:oidc:client_id"];
                options.ClientSecret = Configuration["auth:oidc:client_secret"];
                options.SignedOutRedirectUri = "/";
                System.Collections.Generic.List<string> scopes = Configuration.GetSection("auth:oidc:scopes").Get<string[]>().ToList();
                scopes.ForEach(s => options.Scope.Add(s));
            });

            Constants.AdminAPIURL = Configuration.GetValue<string>("AdminApiUrl").ToString();
            services.AddSingleton<IHttpClientAccessor, DefaultHttpClientAccessor>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
