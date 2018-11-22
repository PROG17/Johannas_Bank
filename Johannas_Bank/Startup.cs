using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Johannas_Bank.Email;
using Johannas_Bank.Repo;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Johannas_Bank
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            HostingEnvironment = env;
        }

        public IConfiguration Configuration { get; }
        public IHostingEnvironment HostingEnvironment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            if (HostingEnvironment.IsDevelopment() || HostingEnvironment.IsEnvironment("Stage") || HostingEnvironment.IsEnvironment("Integration"))
            {
                services.AddTransient<IEmailsender, TestEmailSender>();
            }
            else if (HostingEnvironment.IsEnvironment("Production"))
            {
                services.AddTransient<IEmailsender, ProductionEmailSender>();
            }

            services.AddSingleton<BankRepository>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment() || env.IsEnvironment("Stage") || env.IsEnvironment("Integration"))
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else if(env.IsEnvironment("Production"))
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
