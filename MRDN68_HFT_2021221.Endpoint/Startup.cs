using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MRDN68_HFT_2021221.Data;
using MRDN68_HFT_2021221.Endpoint.Services;
using MRDN68_HFT_2021221.Logic;
using MRDN68_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MRDN68_HFT_2021221.Endpoint
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
            services.AddControllers();

            services.AddTransient<IShowtimeLogic, ShowtimeLogic>();
            services.AddTransient<IMovieLogic, MovieLogic>();
            services.AddTransient<IDirectorLogic, DirectorLogic>();

            services.AddTransient<IShowtimeRepository, ShowtimeRepository>();
            services.AddTransient<IMovieRepository, MovieRepository>();
            services.AddTransient<IDirectorRepository, DirectorRepository>();

            services.AddTransient<MovieProgrammeDbContext, MovieProgrammeDbContext>();

            services.AddSignalR();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MovieDbApp.Endpoint", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseCors(x => x
           .AllowCredentials()
           .AllowAnyMethod()
           .AllowAnyHeader()
           .WithOrigins("http://localhost:2280"));

            app.UseRouting();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json","MovieDbApp.Endpoint v1"));

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<SignalRHub>("/hub");
            });
        }
    }
}
