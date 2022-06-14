using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APAC.Garb.Service.AutoMapper;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using APAC.Garb.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore;
using Microsoft.Extensions.Logging;
using APAC.Garb.Business;
using APAC.Garb.Data;
using APAC.Garb.Business.Components.Definition;
using APAC.Garb.Business.Components.Implementation;
using APAC.Garb.Data.Repository.Definition;
using APAC.Garb.Data.Repository.Implementation;
using APAC.Garb.Data.DbContexts;
using APAC.Garb.Data.DbContexts.Implementations;

namespace APAC.Garb.Service
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

            #region DependencyInjectionConfiguration
            //dbContext
            services.AddDbContext<RequestItemContext>(opt =>
            {
                opt.UseInMemoryDatabase("RequestItems");
            });

            //component
            services.AddScoped<IRequestItemsComponent, RequestItemsComponent>();

            //repository
            services.AddTransient<IRequestItemsRepository, RequestItemsRepository>();

            #endregion

            services.AddSwaggerGen(opt => opt.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Swagger APAC", Version = "v1" }));

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
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
            app.UseSwagger();
            app.UseSwaggerUI(opt =>
            {
                opt.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger APAC");
                opt.RoutePrefix = "swagger/ui";
            });


            app.UseEndpoints(endpoint =>
            {
                endpoint.MapControllers();
            });
        }
    }
}
