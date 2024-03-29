using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloggingSystem.DTO.View_Model;
using BloggingSystemBLLManager;
using BloggingSystemDatabase;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using Service.BloggingSystem.Handler;

namespace Service.BloggingSystem
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
            services.AddControllers()
                    .AddNewtonsoftJson(options =>
                    {
                        options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                    });
            services.AddControllers();
            services.AddDbContext<BloggingSystemDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Connection")), ServiceLifetime.Transient);

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
            services.Configure<JwtTokenSetting>(Configuration.GetSection("JwtTokenSetting"));
            services.AddScoped<IUserBLLManager, UserBLLManager>();
            services.AddScoped<IRoleBLLManager, RoleBLLManager>();
            services.AddScoped<ISecurityBLLManager, SecurityBLLManager>();
            services.AddScoped<IUserRoleBLLManager, UserRoleBLLManager>();
            services.AddScoped<ICategoriesBLLManager, CategoriesBLLManager>();
            services.AddScoped<IPostBLLManager, PostBLLManager>();
            services.AddScoped<ICommentBLLManager, CommentBLLManager>();
            services.AddScoped<IAuthenticationManager, AuthenticationManager>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMiddleware<JwtMiddleware>();

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors("CorsPolicy");
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            //app.UseMiddleware<JwtMiddleware>();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
