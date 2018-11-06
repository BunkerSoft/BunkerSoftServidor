using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Serialization;
using BunkerSoftServidor.Models;


namespace BunkerSoftServidor
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
            services.AddCors(options => options.AddPolicy("AllowAll", p => p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
         /*   services.AddTransient(typeof(IApplicationRepository<>), typeof(ApplicationRepository<>));
            services.AddScoped(typeof(IApplicationRepository<>), typeof(ApplicationRepository<>));
            services.AddSingleton(typeof(IApplicationRepository<>), typeof(ApplicationRepository<>));
         */
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1).AddJsonOptions(options => options.SerializerSettings.ContractResolver =new DefaultContractResolver());  
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors("AllowAll");

            if (env.IsDevelopment())
            {
               app.UseBrowserLink();
               app.UseDeveloperExceptionPage();
               app.UseDatabaseErrorPage();
    
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }


            app.UseHttpsRedirection();
            
            app.UseStaticFiles();
            //app.UseSpaStaticFiles();
           

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

/*
            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
            */
        }
    }
}
