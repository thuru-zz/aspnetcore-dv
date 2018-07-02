using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LayeredProject.DataContext;
using LayeredProject.Services.BusinessServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace LayeredProject
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // This is right
            services.AddSingleton<IProductService, ProductService>();

            // This will fail - you can see the error in Output window under the Build tab
            // The error tab does not show this, and no red squiggly :(
            // uncomment this line to make the build success
            services.AddSingleton<IMyDbContext, MyDbContext>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
