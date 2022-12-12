using Microsoft.AspNetCore.Authentication.JwtBearer;

using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

using Services.Extentions;
using Services.Dtos;
using Services.Interfaces;
using JoRoomWebApplication.Constants;
using Authentication.Helpers;
using Authentication.Options;
using System;
using Microsoft.Extensions.Configuration;

namespace JoRoomWebApplication
{
    public class StartUp
    {
        public IConfiguration Configuration { get; }
        public StartUp(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbServices();
            services.AddControllersWithViews();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = AuthOptions.ValidateIssuer,
                        ValidIssuer = AuthOptions.ValidIssuer,
                        ValidateAudience = AuthOptions.ValidateAudience,
                        ValidAudience = AuthOptions.ValidAudience,
                        ValidateLifetime = AuthOptions.ValidateLifetime,
                        IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                        ValidateIssuerSigningKey = AuthOptions.ValidateIssuerSigningKey,
                    };
                });
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else 
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseAuthentication();
            app.UseEndpoints(builder =>
            {
                builder.MapControllerRoute(
                    name: "default",
                    pattern: RouteConstants.DefaultPattern);
            });
            
        }
    }
}
