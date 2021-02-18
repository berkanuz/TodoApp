using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Berkan.Data;
using Berkan.Engines;
using Berkan.Engines.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;

namespace Berkan.App
{
    public class Startup
    {
        public IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
            });
            services.AddControllers();

            services.AddMvcCore(option => option.EnableEndpointRouting = false);
            services.AddRazorPages().AddRazorRuntimeCompilation();
            services.AddDbContext<DAL>(options => options.UseSqlServer(_configuration.GetConnectionString("TodoAppConnectionString")));
            services.AddTransient<ITodoEngine, TodoEngine>();
            services.AddTransient<ITodoItemEngine, TodoItemEngine>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseMvc();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
