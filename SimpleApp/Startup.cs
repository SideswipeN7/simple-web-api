using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using SimpleApp.Configurations;
using SimpleApp.Controllers;
using SimpleApp.Interfaces;
using SimpleApp.Mapper;
using SimpleApp.Models;
using SimpleApp.Services;
using SimpleApp.Validators;
using System;

namespace SimpleApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public ILifetimeScope AutofacContainer { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddRazorPages();

            //Configure Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Simple application", Version = "1.0v" });
            });

            //Json configuration
            var dbConf = Configuration.GetSection("Database").Get<Database>();

            //Configure Autofac
            var builder = new ContainerBuilder();

            builder.RegisterInstance(new MapperConfiguration(conf =>
            {
                conf.AddProfile(new AutoMapperProfile());
            }).CreateMapper()).As<IMapper>();

            builder.RegisterType<VersionService>().SingleInstance().As<IVersionService>();

            builder.RegisterType<ProductCreateValidator>().As<IValidateProductCreateInputModel>();
            builder.RegisterType<ProductUpdateValidator>().As<IValidateProductUpdateInputModel>();
            builder.RegisterType<ProductsContext>().WithParameter("url", dbConf.Url).As<IProductsContext>();
            builder.RegisterType<ProductsService>().As<IProductsService>();
            builder.RegisterType<ProductController>();

            builder.Populate(services);
            AutofacContainer = builder.Build();

            return new AutofacServiceProvider(AutofacContainer);
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
                app.UseHsts();
                app.UseExceptionHandler("/Error");
            }

            app.UseStatusCodePagesWithRedirects("/Error/{0}");

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseEndpoints(e =>
            {
                e.MapControllers();
                e.MapRazorPages();
            });
        }
    }
}