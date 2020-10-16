using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NMC.Extensions;
using NMC.Resources;
using NMC.Services;

namespace NMC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            //cultures = supportedCultures.Select(x => new CultureInfo(x)).ToArray();
        }

        //private string[] supportedCultures = new[] { "en", "ar" };
        //private CultureInfo[] cultures;

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages()
                .AddViewLocalization()
                .AddDataAnnotationsLocalization();

            services.AddPortableObjectLocalization();

            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new List<CultureInfo>
            {
                new CultureInfo("en"),
                new CultureInfo("ar"),
            };

                options.DefaultRequestCulture = new RequestCulture("ar");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });

            //services.AddLocalization(options => options.ResourcesPath = "Resources");

            //services.AddRazorPages()
            //    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
            //    .AddDataAnnotationsLocalization(options => {
            //        options.DataAnnotationLocalizerProvider = (type, factory) =>
            //            factory.Create(typeof(SharedResource));

            //    });

            //services.Configure<RequestLocalizationOptions>(options =>
            //{
            //    options.DefaultRequestCulture = new RequestCulture(supportedCultures[0]);
            //    options.SupportedCultures = cultures;
            //    options.SupportedUICultures = cultures;
            //    options.RequestCultureProviders = new List<IRequestCultureProvider>
            //    {
            //      new QueryStringRequestCultureProvider(),
            //      new CookieRequestCultureProvider()
            //    };
            //});

            // Configure route options
            services.Configure<RouteOptions>(options => {
                options.LowercaseUrls = true;
                options.LowercaseQueryStrings = true;
                options.AppendTrailingSlash = true;
            });

            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //app.UseRequestLocalization(options => {
            //    options.DefaultRequestCulture = new RequestCulture(supportedCultures[0]);
            //    options.SupportedCultures = cultures;
            //    options.SupportedUICultures = cultures;
            //});

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.Use(async (context, next) =>
            {
                
                context.Request.QueryString = context.Request.QueryString.Add("culture", context.User.GetUserLanguage());

                // Do work that doesn't write to the Response.
                await next();
                // Do other work that doesn't write to the Response.
            });

            app.UseRequestLocalization();

            //var localizationOptions = new RequestLocalizationOptions().SetDefaultCulture(supportedCultures[0])
            //    .AddSupportedCultures(supportedCultures)
            //    .AddSupportedUICultures(supportedCultures);


            //app.UseRequestLocalization(localizationOptions);



            app.UseRouting();

            app.UseAuthorization();



            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
