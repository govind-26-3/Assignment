
using ECommerceApplication.Application.Interfaces;
using ECommerceApplication.Infrastructure.Context;
using ECommerceApplication.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerceApplication.Infrastructure
{
    public static class InterfaceServiceRegistration
    {
        public static IServiceCollection AddInterfaceServices(this IServiceCollection services,IConfiguration configuration)
        {
             services.AddDbContext<EcommerceDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("ECommerceWebAppConnString"));


            });
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            return services;

        }
    }
}
