using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreLMS.Core.Interfaces;
using CoreLMS.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using CoreLMS.Application.Services;
using AutoMapper;
using CoreLMS.Core;

namespace CoreLMS.Web
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
            services.AddRazorPages().AddRazorRuntimeCompilation();
            services.AddSwagger();

            services.AddDbContext<AppDbContext>();

            services.AddScoped<IAppDbContext, AppDbContext>();
            //services.AddScoped<IRepository, Repository>();

            services.AddTransient<ITimeEntryService, TimeEntryService>();
            services.AddTransient<IClockifyService, ClockifyService>();
            services.AddTransient<ICourseService, CourseService>();
            services.AddTransient<IAuthorService, AuthorService>();

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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            //Swagger
            app.UseSwagger(c =>
            {
                c.PreSerializeFilters.Add((doc, _) =>
                {
                    //doc.Servers?.Clear(); //没有 servers 属性了，和之前的版本保持一致了
                });
            });
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/V1/swagger.json", "WebApi.Core V1");

                c.RoutePrefix = "";
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapRazorPages();
            });



        }
    }
}
