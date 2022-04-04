using BLL.Abstract;
using BLL.Concrete;
using Dal.Concrete;
using Dal.Repository;
using Data.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DiasProject.API
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
            services.AddSwaggerDocument(config =>
            {
                config.PostProcess = document =>
                {
                    document.Info.Version = "v1";
                    document.Info.Title = "MyTestService";
                    document.Info.Description = "My First Service";
                    document.Info.TermsOfService = "None";
                    document.Info.Contact = new NSwag.OpenApiContact
                    {
                        Name = "TheCodeBuzz",
                        Email = "info@thecodebuzz.com",
                        Url = "thecodebuzz.com"
                    };
                    document.Info.License = new NSwag.OpenApiLicense
                    {
                        Name = "Trademak ",
                        Url = "https://thecodebuzz.com"
                    };
                };
            });

            services.AddControllers();

            services.AddDbContext<DiasContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

            services.AddScoped<IBinaRepository, BinaRepository>();
            services.AddScoped<IBinaBLL, BinaBLL>();

            services.AddScoped<IOdaRepository, OdaRepository>();
            services.AddScoped<IOdaBLL, OdaBLL>();

            services.AddScoped<IEnvanterRepository, EnvanterRepository>();
            services.AddScoped<IEnvanterBLL, EnvanterBLL>();

            services.AddScoped<IDepoRepository, DepoRepository>();
            services.AddScoped<IDepoBLL, DepoBLL>();

            services.AddScoped<IIsEmriRepository, IsEmriRepository>();
            services.AddScoped<IIsEmriBLL, IsEmriBLL>();

            services.AddScoped<IUrunYoluRepository, UrunYoluRepository>();
            services.AddScoped<IUrunYoluBLL, UrunYoluBLL>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {

            

            var path = Directory.GetCurrentDirectory();
            loggerFactory.AddFile($"{path}\\Logs\\Log.txt");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseOpenApi(s =>
            {
                s.PostProcess = (document, request) =>
                {
                    document.Info.Version = "v1";
                    document.Info.Title = "MyTestService";
                    document.Info.Description = "a";
                    document.Info.TermsOfService = "None";
                    //document.Info.Contact = new NSwag.OpenApiContact
                    //{
                    //    Name = "a",
                    //    Email
                    //}
                    //document.Info.License=new NSwag.OpenApiLicense
                    //{
                    //    Name=""
                    //}
                };
            });

            app.UseSwaggerUi3();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
