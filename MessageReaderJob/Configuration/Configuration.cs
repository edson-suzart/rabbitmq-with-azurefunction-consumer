using MessageReader.WebJob.ModelsConnection;
using Microsoft.Extensions.Configuration;

namespace MessageReader.WebJob.Configuration
{
    public static class Configuration
    {
        public static string GetConnectionStringRabbit(IConfiguration configuration)
        {
            var settings = configuration.GetSection("AppSettings:RabbitMQConnection").Get<RabbitMQConnection>();
            return $"amqp://{settings.Username}:{settings.Password}@{settings.Host}:{settings.Port}";
        }
    }
}
