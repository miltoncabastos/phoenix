using Microsoft.Extensions.DependencyInjection;
using Pheonix.Infra.Repository;
using Pheonix.Interfaces.Clients;
using Pheonix.Interfaces.Products;
using Pheonix.Interfaces.Stocks;

namespace Pheonix.API.DependencyInjection
{
    public static class RepositoriesInjection
    {
        public static IServiceCollection AddRepositoriesInjection(this IServiceCollection services)
        {
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IStockRepository, StockRepository>();

            return services;
        }
    }
}
