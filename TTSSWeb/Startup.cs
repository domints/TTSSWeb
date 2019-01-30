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
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TTSSLib.Interfaces;
using TTSSLib.Services;
using TTSSWeb.Services;
using TTSSWeb.Services.Implementations;

namespace TTSSWeb
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
            services.AddSpaStaticFiles(config => config.RootPath = "./wwwroot");
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSingleton<IAutocompleteService, LocalAutocompleteService>();
            services.AddSingleton<IStopCacheService, StopCacheService>();
            services.AddTransient<IStopService, StopService>();
            services.AddTransient<IPassageService, PassageService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IStopCacheService stopCacheService)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseDefaultFiles();
            app.UseSpaStaticFiles();
            app.UseMvc(routes => {
                routes.MapRoute("default", "{controller}/{action=Index}");
                routes.MapRoute("spa", "{*url}", new { controller = "Home", action = "Index"});
            });

            stopCacheService.InitStaticData().Wait();
        }
    }
}
