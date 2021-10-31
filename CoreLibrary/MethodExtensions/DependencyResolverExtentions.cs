using Data.Interfaces;
using Data.Interfaces.Repositories;
using Data.Repositories;
using Domain;
using Domain.Interfaces;
using Domain.Interfaces.Base;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Services;
using Services.Interfaces;
using System;
using System.Globalization;
using System.IO.Compression;

namespace CoreLibrary.MethodExtensions
{
    public static class DependencyResolverExtentions
    {
        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IDepartmentRepository), typeof(DepartmentRepository));
            services.AddScoped(typeof(ICountryRepository), typeof(CountryRepository));
            services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
            services.AddScoped(typeof(IMenuRepository), typeof(MenuRepository));
        }
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IService<>), typeof(Service<>));
            services.AddScoped(typeof(IUserService), typeof(UserService));
            services.AddScoped(typeof(IRegionService), typeof(RegionService));
            services.AddScoped(typeof(ISliderService), typeof(SliderService));
            services.AddScoped(typeof(IBlogService), typeof(BlogService));
            services.AddScoped(typeof(ISettingsHelper), typeof(SettingsHelper));
            services.AddScoped(typeof(IPackageService), typeof(PackageService));
            services.AddScoped(typeof(IAppointmentService), typeof(AppointmentService));
            services.AddScoped(typeof(IDailyCheckService), typeof(DailyCheckService));
            


        }
        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IDbContextOptions>(options => (new DbContextOptionsBuilder()).UseSqlServer(configuration.GetConnectionString("DefaultConnection")).Options);
            services.AddDbContext<Data.DataContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
            );
        }
        public static void ConfigureGeneral(this IServiceCollection services)
        {
            services.AddResponseCompression(opt =>
            {
                opt.Providers.Add<GzipCompressionProvider>();
                opt.EnableForHttps = true;
            });
            services.Configure<GzipCompressionProviderOptions>(options => options.Level =
            CompressionLevel.Fastest);
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddDistributedMemoryCache();
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                    builder.SetIsOriginAllowed(_ => true)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });
            // Auth
            services.AddAuthorization();
            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[]
                {
                    new CultureInfo("tr")
                };
                options.DefaultRequestCulture = new RequestCulture(culture: "tr", uiCulture: "tr");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });
        }
    }
}
