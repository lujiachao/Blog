using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyBlog.Web.MiddleWare;
using MyDapper;
using Newtonsoft.Json;

namespace MyBlog.Web
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
            services.AddDispatch();
            services.AddCors(_options => _options.AddPolicy("AllowCors", _builder => _builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials()));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            MyblogConfigurationProvider.serviceProvider = app.ApplicationServices;
            MyDapperPower.DbConnection(MyblogConfigurationProvider.DbConfiguration.ConnectionString, MyblogConfigurationProvider.DbConfiguration.DbType, MyblogConfigurationProvider.DbConfiguration.DbType);

            if (env.IsDevelopment())
            {
                app.UseMiddleware(typeof(ExceptionHandlerMiddleWare));
            }
            else
            {
                app.UseMiddleware(typeof(ExceptionHandlerMiddleWare));
                app.UseHsts();
            }
            app.UseCors("AllowCors");
            //app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
