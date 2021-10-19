using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using PopulationAnalyzer.DomainModels;
using PopulationAnalyzer.Helpers;
using PopulationAnalyzer.Repositories;
using PopulationAnalyzer.Repositories.UnitOfWork;
using PopulationAnalyzer.Services;
using PopulationAnalyzer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PopulationAnalyzer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        readonly string DevOrigins = "_DevOrigins";
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            services.AddCors(options =>
            {
                options.AddPolicy(name: DevOrigins, builder =>
                {
                    builder.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
                });
            });

            // Scoped
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IPopulationMockRepository, PopulationMockRepository>();
            services.AddScoped<IPopulationService, PopulationService>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PopulationAnalyzer", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PopulationAnalyzer v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(DevOrigins);

            app.UseAuthorization();

            app.UseMiddleware<ErrorHandlerMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
