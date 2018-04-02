using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using StructureMap;
using Swashbuckle.AspNetCore.Swagger;

namespace Mining.Presentation
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddSwaggerGen(c =>
           {
               c.SwaggerDoc("v1", new Info { Title = "Mapping API", Version = "v1" });
           });

            return ConfigureStructureMap(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mining API V1");
            });
            app.UseMvc();
        }

        private IServiceProvider ConfigureStructureMap(IServiceCollection services)
        {
            var container = new Container();

            container.Configure(cfg =>
            {
               
                cfg.Scan(_ =>
                {
                    _.AssembliesFromApplicationBaseDirectory();
                    _.LookForRegistries();
                    _.WithDefaultConventions();
                });

                
                
                cfg.Populate(services);
            });

            return container.GetInstance<IServiceProvider>();
        }

    }
}
