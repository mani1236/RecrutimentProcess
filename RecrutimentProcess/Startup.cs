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
using RecruitmentProcess.Contracts.Services;
using RecruitmentProcess.Infrastracture.Dbcontext;
using RecruitmentProcess.Infrastracture.Repositories;
using RecrutimentProcess.Controllers;

namespace RecrutimentProcess
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
            services.AddControllers();
            string cnnectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<RecruitmentContext>(option => option.UseSqlServer(cnnectionString));

            services.AddScoped<ICandidateDetailsRepository, CandidateDetailsRepository>();
            services.AddTransient<ICandidateService, CandidateService>();
            services.AddSingleton<ILogger>(provider =>
             provider.GetRequiredService<ILogger<CandidateDetailsController>>());
            services.AddControllers().AddNewtonsoftJson(options =>
             options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

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
