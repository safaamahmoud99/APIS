using BL.Bases;
using DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL.AppService;
using AutoMapper;
using BL.interfaces;
using DAL.Models;

namespace WEP_APICore
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
            services.AddCors(CorsOptions => CorsOptions.AddPolicy("MyPolicy",
              builder => builder.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin()));
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WEP_APICore", Version = "v1" });
            });
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<UserManager<User>>();
            services.AddTransient<RoleManager<IdentityRole>>();
            services.AddTransient<AccountAppService>();
            services.AddTransient<CartAppService>();
            services.AddTransient<CategoryAppService>();
            services.AddTransient<OrderAppService>();
            services.AddTransient<OrderDetailsAppservice>();
            services.AddTransient<ProductAppService>();
            services.AddTransient<CartProductAppService>();
            services.AddTransient<WishListProductAppService>();
            services.AddTransient<WishListAppService>();
            services.AddTransient<ReviewAppService>();
            services.AddTransient<SupplierAppService>();
            services.AddTransient<ImageAppService>();
            services.AddTransient<BrandAppService>();
            services.AddTransient<MainCategoryAppService>();
            services.AddTransient<SubCategoryAppService>();
            services.AddHttpContextAccessor();//allow me to get user information such as id
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WEP_APICore v1"));
            }
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
