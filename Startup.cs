using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ParabolicFunction.Models;
using System.Net.Http.Headers;

namespace ParabolicFunction
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
            services.AddTransient<IDataRepository, EFDataRepository>();
            //services.AddSingleton<IDataRepository, EFDataRepository>();

            services.AddMvc();
            //.AddXmlDataContractSerializerFormatters()
            //.AddMvcOptions(opts => {
            //    opts.FormatterMappings.SetMediaTypeMappingForFormat("xml",
            //        new MediaTypeHeaderValue("application/xml"));          The source represented as a string to initialize the new instance ERRRRRROORRRR!!!!!!!!!
            //    opts.RespectBrowserAcceptHeader = true;
            //    opts.ReturnHttpNotAcceptable = true;
            //});

            services.AddMemoryCache();
            services.AddSession();

            string conString = Configuration["ConnectionStrings:DefaultConnection"];
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(conString));
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
                app.UseExceptionHandler();
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseMvcWithDefaultRoute();
        }
    }
}
