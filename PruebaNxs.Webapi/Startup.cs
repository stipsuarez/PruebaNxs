using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using PruebaNxs.Abstractions;
using PruebaNxs.Appliation;
using PruebaNxs.DataAccess;
using PruebaNxs.Repository;
using Oracle.ManagedDataAccess.Client;


namespace PruebaNxs.Webapi
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PruebaNxs.Webapi", Version = "v1" });
            });
            //inyectamos el repositorio y la applicacion y connection

            services.AddDbContext<ApiDbContext>(options =>
            options.UseOracle(
                Configuration.GetConnectionString("OracleConnection"),
                b => b.MigrationsAssembly("PruebaNxs.Webapi"))
            
            ) ;
            services.AddScoped(typeof(IApplication<>), typeof(Application<>));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IDbContext<>), typeof(DbContext<>));

            //habilitamos las conexiones
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.WithMethods("*");
                                      builder.WithHeaders("*");
                                      builder.WithOrigins("*")
                                      .AllowAnyMethod()
                                      .AllowAnyHeader();
                                  });
            });
            
            // Add framework services.
            services.AddMvc();
           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PruebaNxs.Webapi v1"));
            }
            
            app.UseHttpsRedirection();

            app.UseRouting();

           
            app.UseCors(MyAllowSpecificOrigins);
            app.UseAuthorization();
            

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllers();
                endpoints.MapControllers().RequireCors(MyAllowSpecificOrigins);
            });
        }
    }
}
