using API.Infrastructure.RabbitQueueService;
using API.ModelsConnections;
using API.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;

namespace API.StartupConfigurations
{
    public static class AppServices
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            var settings = configuration.GetSection("AppSettings:RabbitMQConnection").Get<RabbitMQConnection>();

            services
                .AddScoped<IProductService, ProductService>()
                .AddSingleton<IRabbitService, RabbitService>()
                .AddSingleton<IConnectionFactory, ConnectionFactory>(queue =>
                    new ConnectionFactory()
                    {
                        HostName = settings.Host,
                        Port = settings.Port,
                        UserName = settings.Username,
                        Password = settings.Password
                    });

            return services;
        }
    }
}
