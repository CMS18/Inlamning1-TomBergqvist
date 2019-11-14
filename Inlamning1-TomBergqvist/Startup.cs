using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Inlamning1_TomBergqvist
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);


            // Setting up som customers and accounts
            var repository = new Models.BankRepository();

            repository.Customers.Add(new Models.Customer(1,"Sir Bobby", "La Bob"));
            repository.Customers.Add(new Models.Customer(2, "Lucindel", "Lurfvelkurvelhopf Von Kirkenhal"));
            repository.Customers.Add(new Models.Customer(3, "David", "Hasselhoff"));

            repository.Accounts.Add(new Models.Account(1, 1, 5000000m));
            repository.Accounts.Add(new Models.Account(2, 2, 9000000m));
            repository.Accounts.Add(new Models.Account(3, 3, 0.5m));
            repository.Accounts.Add(new Models.Account(4, 1, 10000m));
            repository.Accounts.Add(new Models.Account(5, 1, 3500000m));

            services.AddSingleton(repository);
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
