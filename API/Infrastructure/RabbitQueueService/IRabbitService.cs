using System.Threading.Tasks;

namespace API.Infrastructure.RabbitQueueService
{
    public interface IRabbitService
    {
        void SendQueueRabbit(byte[] item);
    }
}