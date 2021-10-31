using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CoreLibrary;
using CoreLibrary.MethodExtensions;
using Data.Interfaces;
using Data.Interfaces.Repositories;
using Data.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace Admin
{
    public class Startup
    {
        // test
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureGeneral();
            services.ConfigureDbContext(Configuration);
            services.ConfigureRepositories();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options => { options.AccessDeniedPath = "/AdminPAnel/Giris"; options.LoginPath = "/AdminPAnel/Giris"; options.ExpireTimeSpan = TimeSpan.FromHours(1); });
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            ServiceActivator.Configure(app.ApplicationServices);
            var settings = app.ApplicationServices.GetService<IConfiguration>();
            app.UseFileServer(new FileServerOptions
            {
                FileProvider = new PhysicalFileProvider(settings["BaseFileDirectory"]),
                RequestPath = new PathString(settings["BaseFileSharePath"]),
                EnableDirectoryBrowsing = false
            }
            );
            var locOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(locOptions.Value);
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseResponseCompression();
            app.UseCors(builder => builder.WithOrigins("/"));
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseSession();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCookiePolicy();
            app.UseCors("CorsPolicy");
            app.UseStaticFiles();
            app.UseStatusCodePages(async context =>
            {
                var response = context.HttpContext.Response;
                //if (response.StatusCode == (int)HttpStatusCode.Unauthorized ||
                //    response.StatusCode == (int)HttpStatusCode.Forbidden)
                //    response.Redirect("/AdminPanel/Giris");
                //if (response.StatusCode == (int)HttpStatusCode.NotFound ||
                //    response.StatusCode == (int)HttpStatusCode.Forbidden)
                //    response.Redirect("/");
            });

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=AdminPanel}/{action=Giris}/{id?}");

            });
        }
    }
}
