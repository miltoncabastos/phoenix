using Microsoft.Extensions.DependencyInjection;
using Pheonix.Service.Interfaces;
using Pheonix.Service.Services;

namespace Pheonix.API.DependencyInjection
{
    public static class ServicesInjection
    {
        public static IServiceCollection AddServicesInjection(this IServiceCollection services)
        {
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IStockService, StockService>();

            return services;
        }
    }
}
