using RabbitMQ.Client;

namespace API.Infrastructure.RabbitQueueService
{
    public class RabbitService : IRabbitService
    {
        private readonly IConnectionFactory _connectionFactory;
        private readonly string queue_name = "product-queue";

        public RabbitService(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public void SendQueueRabbit(byte[] item)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue_name, false, false, false, null);
                    
                    channel
                        .BasicPublish(
                            exchange: string.Empty,
                            routingKey: queue_name,
                            basicProperties: null,
                            body: item);
                }
            }
        }
    }
}
