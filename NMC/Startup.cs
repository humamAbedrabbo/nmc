using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NMC.Extensions;
using NMC.Core.Services;
using NMC.Infrastructure.Services;
using SBMenu;
using NMC.Infrastructure;

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
            if(!string.IsNullOrEmpty(Configuration["KnownProxy"]))
            {
                services.Configure<ForwardedHeadersOptions>(options =>
                {
                    options.KnownProxies.Add(IPAddress.Parse(Configuration["KnownProxy"]));
                });
            }

            services.AddRazorPages(x => x.Conventions.AuthorizeFolder("/"))
                .AddViewLocalization()
                .AddDataAnnotationsLocalization();

            services.AddPortableObjectLocalization();

            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new List<CultureInfo>();
                var en = new CultureInfo("en");
                en.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
                en.DateTimeFormat.DateSeparator = "/";
                en.DateTimeFormat.Calendar = new GregorianCalendar();
                supportedCultures.Add(en);

                var ar = new CultureInfo("ar");
                ar.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
                ar.DateTimeFormat.DateSeparator = "/";
                ar.DateTimeFormat.Calendar = new GregorianCalendar();
                supportedCultures.Add(ar);

                options.DefaultRequestCulture = new RequestCulture("en");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });

            // Configure route options
            services.Configure<RouteOptions>(options => {
                options.LowercaseUrls = true;
                options.LowercaseQueryStrings = true;
                options.AppendTrailingSlash = true;
            });

            services.AddInfrastructureServices();
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

            app.UseHttpsRedirection();
            app.UseStaticFiles();


            app.UseRequestLocalization();

            app.UseRouting();

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            app.UseAuthentication();

            app.UseAuthorization();

            app.Use(async (context, next) =>
            {
                context.Request.QueryString = context.Request.QueryString.Add("culture", context.User.GetUserLanguage());
                await next();
            });

            app.UseEndpoints(endpoints =>
            {
                
                endpoints.MapRazorPages();
            });
        }
    }
}
