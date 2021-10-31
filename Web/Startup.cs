using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Reflection;
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
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;

namespace Web
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
            services.ConfigureGeneral();
            services.ConfigureDbContext(Configuration);
            services.ConfigureRepositories();
            services.AddHostedService<TimedHostedService>();  // Timer servisleri , zamana bagl� i�lem yapt�rma
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options => { options.AccessDeniedPath = "/Doctorla/Giris"; options.LoginPath = "/Doctorla/Giris"; options.ExpireTimeSpan = TimeSpan.FromHours(1); });
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var locOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(locOptions.Value);
            var settings = app.ApplicationServices.GetService<IConfiguration>();
            app.UseFileServer(new FileServerOptions
            {
                FileProvider = new PhysicalFileProvider(settings["BaseFileDirectory"]),
                RequestPath = new PathString(settings["BaseFileSharePath"]),
                EnableDirectoryBrowsing = false
            }
            );

            ServiceActivator.Configure(app.ApplicationServices);
            if (Convert.ToBoolean(settings["ShowErrors"]))
                app.UseDeveloperExceptionPage();
            else
                app.UseStatusCodePages();
            //if (env.IsDevelopment())
            //{
            //      app.UseDeveloperExceptionPage();
            //}
            //else
            //{
            //    app.UseExceptionHandler("/Home/Error");
            //    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //    app.UseHsts();
            //}
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
            //app.UseStatusCodePages(async context =>
            //{
            //    var response = context.HttpContext.Response;  // Sayfa statuslar�na g�re istedi�im sayfaya y�nlendirme
            //    //if (response.StatusCode == (int)HttpStatusCode.Unauthorized ||
            //    //    response.StatusCode == (int)HttpStatusCode.Forbidden)
            //    //    response.Redirect("/Saglikcim/Giris");
            //    //if (response.StatusCode == (int)HttpStatusCode.NotFound ||
            //    //    response.StatusCode == (int)HttpStatusCode.Forbidden)
            //    //    response.Redirect("/");
            //});
            app.UseRewriter(new RewriteOptions().Add(new RedirectWwwRule()));
            app.UseEndpoints(endpoints =>  // route ayarlar�, linklemelerde parametreleri &Username=test degilde /test olarak almam�z sagl�yor
            {
                endpoints.MapControllerRoute(
                name: "SifreSifirlama",
                pattern: "Saglikcim/SifreSifirlama/{refreshToken}",
                defaults: new { controller = "Saglikcim", action = "SifreSifirlama" });
                endpoints.MapControllerRoute(
                 name: "Doktorlarimiz",
                 pattern: "Saglikcim/Doktorlarimiz/{BolumAdi}",
                 defaults: new { controller = "Saglikcim", action = "Doktorlarimiz" });
                endpoints.MapControllerRoute(
                 name: "DoktorBilgileri",
                 pattern: "Saglikcim/DoktorBilgileri/{BolumAdi}/{id}/{DoktorAdi}",
                 defaults: new { controller = "Saglikcim", action = "DoktorBilgileri" });
                endpoints.MapControllerRoute(
                 name: "Blog",
                 pattern: "Blog",
                 defaults: new { controller = "AcilDurum", action = "blog" });
                endpoints.MapControllerRoute(
                 name: "Blog-tag",
                 pattern: "Blog/tag/{postTag}",
                 defaults: new { controller = "AcilDurum", action = "blog" });
                endpoints.MapControllerRoute(
                 name: "Blog-category",
                 pattern: "Blog/category/{postCategory}",
                 defaults: new { controller = "AcilDurum", action = "blog" });
                endpoints.MapControllerRoute(
                 name: "Blog-post",
                 pattern: "Blog/post/{seoUrl}",
                 defaults: new { controller = "AcilDurum", action = "post" });
                endpoints.MapControllerRoute(
                 name: "LiveChat",
                 pattern: "Saglikcim/LiveChat/{roomname}",
                 defaults: new { controller = "Saglikcim", action = "LiveChat" });
                endpoints.MapControllerRoute(
                 name: "default",
                 pattern: "{controller=Saglikcim}/{action=Anasayfa}/{id?}");
                endpoints.MapControllerRoute(
                 name: "AdminRandevuIslemleri",
                 pattern: "AdminPanel/RandevuIslemleri/{id}/{username}/{doctorname}/{sessioncode}",
                 defaults: new { controller = "AdminPanel", action = "RandevuIslemleri" });
                endpoints.MapControllerRoute(
                 name: "AdminPaketIslemleri",
                 pattern: "AdminPanel/Paketler/{id}/{name}",
                 defaults: new { controller = "AdminPanel", action = "Paketler" });

                endpoints.MapControllerRoute(
                 name: "Doctorla",
                 pattern: "Doctorla/{action}",
                 defaults: new { controller = "Saglikcim" });
                endpoints.MapControllerRoute(
                 name: "Doctorla-LiveChat",
                 pattern: "Doctorla/LiveChat/{roomname}",
                 defaults: new { controller = "Saglikcim", action = "LiveChat" });
                endpoints.MapControllerRoute(
                name: "Doctorla-SifreSifirlama",
                pattern: "Doctorla/SifreSifirlama/{refreshToken}",
                defaults: new { controller = "Saglikcim", action = "SifreSifirlama" });
                endpoints.MapControllerRoute(
                 name: "Doctorla-Doktorlarimiz",
                 pattern: "Doctorla/Doktorlarimiz/{BolumAdi}",
                 defaults: new { controller = "Saglikcim", action = "Doktorlarimiz" });
                endpoints.MapControllerRoute(
                 name: "Doctorla-DoktorBilgileri",
                 pattern: "Doctorla/DoktorBilgileri/{BolumAdi}/{id}/{DoktorAdi}",
                 defaults: new { controller = "Saglikcim", action = "DoktorBilgileri" });
                endpoints.MapControllerRoute(
                name: "Privacy",
                pattern: "Gizlilik",
                defaults: new { controller = "Saglikcim", action = "privacy_policy" });

                endpoints.MapControllerRoute(
                name: "SalePolicy",
                pattern: "satispolitikasi",
                defaults: new { controller = "Saglikcim", action = "satispolitikasi" });
                endpoints.MapControllerRoute(
                name: "CookiePolicy",
                pattern: "CerezPolitikasi",
                defaults: new { controller = "Saglikcim", action = "CerezPolitikasi" });

            });
        }
    }
    public class RedirectWwwRule : IRule
    {
        public int StatusCode { get; } = (int)HttpStatusCode.MovedPermanently;
        public bool ExcludeLocalhost { get; set; } = true;

        public void ApplyRule(RewriteContext context)
        {
            var request = context.HttpContext.Request;
            var host = request.Host;
            if (host.Host.StartsWith("www", StringComparison.OrdinalIgnoreCase))
            {
                context.Result = RuleResult.ContinueRules;
                return;
            }

            if (ExcludeLocalhost && string.Equals(host.Host, "localhost", StringComparison.OrdinalIgnoreCase))
            {
                context.Result = RuleResult.ContinueRules;
                return;
            }

            if (host.Host.StartsWith("stage", StringComparison.OrdinalIgnoreCase))
            {
                context.Result = RuleResult.ContinueRules;
                return;
            }

            string newPath = request.Scheme + "://www." + host.Value + request.PathBase + request.Path + request.QueryString;

            var response = context.HttpContext.Response;
            response.StatusCode = StatusCode;
            response.Headers[HeaderNames.Location] = newPath;
            context.Result = RuleResult.EndResponse; // Do not continue processing the request
        }
    }
}
