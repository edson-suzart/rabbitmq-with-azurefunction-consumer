using API.Infrastructure.RabbitQueueService;
using API.Models;
using Newtonsoft.Json;
using System.Text;

namespace API.Service
{
    public class ProductService : IProductService
    {
        private readonly IRabbitService _serviceBusService;

        public ProductService(IRabbitService serviceBusService)
        {
            _serviceBusService = serviceBusService;
        }

        public void SendProductModelQueue(ProductModel productModel) => 
            _serviceBusService.SendQueueRabbit(GetProductConfigured(productModel));
        
        private static byte[] GetProductConfigured(ProductModel productModel) =>
            Encoding.ASCII.GetBytes(
                JsonConvert.SerializeObject(productModel));
    }
}
