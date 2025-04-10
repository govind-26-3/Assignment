﻿using Asp.Versioning;
using Microsoft.Extensions.Options;

namespace BoilerPlate.Api.Services
{
    public static class AddVersioningServices
    {
        public static void AddApiVersion(this IServiceCollection services)
        {
            services.AddApiVersioning(
                options =>
                {
                    options.DefaultApiVersion = new ApiVersion(1, 0);
                    options.AssumeDefaultVersionWhenUnspecified = true;
                    options.ReportApiVersions = true;
                })
            .AddApiExplorer(options =>
             {
                 options.GroupNameFormat = "'v'VVV";
                 options.SubstituteApiVersionInUrl = true;
             });
        }
    }
}
