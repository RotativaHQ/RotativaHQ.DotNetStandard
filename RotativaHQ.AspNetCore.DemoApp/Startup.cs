﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace RotativaHQ.AspNetCore.DemoApp
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
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
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

            RotativaHqConfiguration.SetRotativaHqApiKey("b4301d1a95c2492b9b3fbacf380fbf55");
            RotativaHqConfiguration.SetRotativaHqUrl("https://eunorth.rotativahq.com");
            //RotativaHqConfiguration.SetRotativaHqUrl("http://localhost.fiddler:1282");
            //RotativaHqConfiguration.SetRotativaHqUrl("http://ee7c4b23275a4e30942aec403db8b5e4.cloudapp.net");
        }
    }
}
