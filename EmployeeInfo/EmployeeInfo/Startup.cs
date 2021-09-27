using EmployeeInfo.Contracts.Entities;
using EmployeeInfo.Common.Logging;
using EmployeeInfo.Contracts.Abstract;
using EmployeeInfo.Contracts.Entities;
using EmployeeInfo.Data;
using EmployeeInfo.Data.Concrete;
using EmployeeInfo.Data.DataContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace EmployeeInfo
{
    public class Startup
    {
        public readonly IHostingEnvironment HostingEnvironment;
        public IConfigurationRoot Configuration { get; }
        public Startup(IHostingEnvironment env)
        {
            HostingEnvironment = env;
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: false)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
            //env.ConfigureLog4Net("log4net.xml");
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });



            //Also make top level configuration available (for EF configuration and access to connection string)
            services.AddSingleton(Configuration); //IConfigurationRoot
            services.AddSingleton<IConfiguration>(Configuration);


            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("IdentityConnection")));

            services.AddDefaultIdentity<ApplicationUser>()
                .AddDefaultUI(UIFramework.Bootstrap4)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            //Added for session state
            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(10);
            });

            //Set database.
            if (Configuration["AppConfig:UseInMemoryDatabase"] == "true")
            {
                services.AddDbContext<EmployeeInfoContext>(options => options.UseInMemoryDatabase("EmployeeInfoMemory"));
            }
            else
            {
                services.AddDbContext<EmployeeInfoContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("EmployeeInfoConnection")));
            }
            services.AddMvc(
                options =>
                {
                    //options.ModelBinderProviders.Insert(0, new QuoteBinderProvider());
                }
            ).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            //services.AddScoped<ICustomerService, CustomerService>();
            //services.AddScoped<IUserService, UserService>();
            //services.AddScoped<IDealerService, DealerService>();
            //services.AddScoped<IDealerRepository, DealerRepository>();
            //services.AddScoped<ICustomerRepository, CustomerRepository>();
            //services.AddScoped<IUserRepository, UserRepository>();
            //services.AddScoped<IQuoteMasterService, QuoteMasterService>();
            //services.AddScoped<IQuoteMasterRepository, QuoteMasterRepository>();
            //services.AddScoped<WorkFlowFilter>();
            //services.AddTransient<BreadcrumbService>();
            services.AddMvc().Services.Configure<MvcOptions>(options => {
                //options.ModelBinderProviders.Insert(0, new QuoteBinderProvider());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseSession();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            loggerFactory.AddLog4Net(env);
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
