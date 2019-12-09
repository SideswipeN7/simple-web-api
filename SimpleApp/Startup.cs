using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleApp.Controllers;
using SimpleApp.Interfaces;
using SimpleApp.Models;
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
            services.AddMvc();

            //Configure Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info() { Title = "Simple application", Version = "1.0v" });
            });

            //Configure Autofac
            var builder = new ContainerBuilder();
            builder.Register(e => new ProductsContext("Gi7aS-3urq3_"));
            builder.RegisterType<ProductCreateValidator>().As<IValidateProductCreateInputModel>().SingleInstance();
            builder.RegisterType<ProductUpdateValidator>().As<IValidateProductUpdateInputModel>().SingleInstance();
            builder.Register(c => new ProductController(c.Resolve<ProductsContext>(), c.Resolve<IValidateProductCreateInputModel>(), c.Resolve<IValidateProductUpdateInputModel>())).SingleInstance();
            builder.Populate(services);          
            AutofacContainer = builder.Build();   

            AutofacContainer.Resolve<ProductController>();
            return new AutofacServiceProvider(AutofacContainer);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseStaticFiles();

            app.UseMvc();
        }
    }
}
