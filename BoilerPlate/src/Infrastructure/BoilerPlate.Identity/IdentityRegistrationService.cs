﻿using BoilerPlate.Application.Interfaces.Identity;
using System.Text;
using BoilerPlate.Application.Models.Identity;
using BoilerPlate.Identity.Context;
using BoilerPlate.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using BoilerPlate.Identity.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;



namespace BoilerPlate.Identity
{
    public static class IdentityRegistrationService
    {
        
            public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
            {
                services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

                services.AddDbContext<ApplicationIdentityDbContext>(options =>

                    options.UseSqlServer(configuration.GetConnectionString("BoilerPlateConnectionString")));

                services.AddIdentity<ApplicationUser, IdentityRole>().
                    AddEntityFrameworkStores<ApplicationIdentityDbContext>().AddDefaultTokenProviders();

                services.AddTransient<IAuthService, AuthService>();
                services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                }).AddJwtBearer(o =>
                {
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = configuration["JwtSettings:Issuer"],
                        ValidAudience = configuration["JwtSettings:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]))
                    };
                });



                return services;
            }
        
    }
}
