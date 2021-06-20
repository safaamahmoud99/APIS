using BL.Bases;
using DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.FileProviders;
using System.IO;
using Microsoft.AspNetCore.Http;
using BL.Hubs;

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
            //For Identity
            services.AddIdentity<User, IdentityRole>()
               .AddEntityFrameworkStores<ApplicationDbContext>()
               .AddDefaultTokenProviders();

            services.AddCors(CorsOptions => CorsOptions.AddPolicy("MyPolicy",
              builder => builder.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin()));
            services.AddControllers();
            services.AddDbContext<ApplicationDbContext>(option => {
                option.UseSqlServer(Configuration.GetConnectionString("CS"),
                    options => options.EnableRetryOnFailure());
            });
            services.AddSignalR();
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
            services.AddTransient<OfferAppservice>();
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
            services.AddTransient<AdvertisementAppService>();
            services.AddHttpContextAccessor();//allow me to get user information such as id
            services.AddAutoMapper(typeof(Startup));
            //services.AddAuthentication()
            //.AddGoogle("google", opt =>
            //{
            //    var googleAuth = Configuration.GetSection("Authentication:Google");

            //    opt.ClientId = googleAuth["ClientId"];
            //    opt.ClientSecret = googleAuth["ClientSecret"];
            //    opt.SignInScheme = IdentityConstants.ExternalScheme;
            //});

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
           {
               options.SaveToken = true;
               options.RequireHttpsMetadata = false;
               options.Audience = Configuration["Jwt:Audience"];
               options.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuer = true,
                   ValidateAudience = true,
                   ValidateLifetime = true,
                   ValidateIssuerSigningKey = true,
                   ValidIssuer = Configuration["Jwt:ValidIssuer"],
                   ValidAudience = Configuration["Jwt:ValidAudience"],
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Secret"]))
               };
           });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WEP_APICore v1"));
            }
            app.UseCors(
                options => options
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials());
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Resources")),
                RequestPath = new PathString("/Resources")
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<SoppingCartWishListHub>("/notify");
                endpoints.MapHub<WishListHub>("/wishList");
                endpoints.MapHub<ReviewHub>("/review");
                endpoints.MapHub<DeleteCartProductHub>("deletecartproduct");
                endpoints.MapHub<DeleteWishListHub>("deletewishList");
            });
        }
    }
}
