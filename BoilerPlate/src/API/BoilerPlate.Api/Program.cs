using BoilerPlate.Persistence;
using BoilerPlate.Application;
using BoilerPlate.Api.Middleware;
using Serilog;
using Asp.Versioning;
using Asp.Versioning.ApiExplorer;
using BoilerPlate.Api.Services;

namespace BoilerPlate.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            IConfiguration configurationBuilder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true)
                .Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configurationBuilder)
                .WriteTo.Console()
                .CreateLogger();

            builder.Host.UseSerilog();


            //api versioning
            builder.Services.AddApiVersion();

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddApplicaionService();
            builder.Services.AddPersistenceRegistration(builder.Configuration);

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();



            builder.Services.AddSwaggerGen(c =>
            {
                        c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "My API - V1", Version = "v1" });
                        c.SwaggerDoc("v2", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "My API - V2", Version = "v2" });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
                app.UseSwagger();
                app.UseSwaggerUI(
                    options =>
                        {
                           foreach (var description in provider.ApiVersionDescriptions)
                              {
           options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                              }
                         });
            }
            app.UseSerilogRequestLogging();
            app.UseMiddleware<ExceptionMiddleware>();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
