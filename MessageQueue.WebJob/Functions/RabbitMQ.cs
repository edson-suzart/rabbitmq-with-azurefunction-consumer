using System.Threading.Tasks;
using MediatR;
using MessageQueue.Models;
using MessageQueue.WebJob.Domain;
using MessageQueue.WebJob.Domain.Command;
using MessageQueue.WebJob.Mappings;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace MessageQueue.WebJob
{
    public class RabbitMQ
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _configuration;

        public RabbitMQ(IMediator mediator, IConfiguration configuration)
        {
            _mediator = mediator;
            _configuration = configuration;
        }

        [FunctionName("MessageRabbitMQTrigger")]
        public async Task ProcessQueueMessage([
            RabbitMQTrigger("product-queue", ConnectionStringSetting = "RabbitMQConnection")] string message)
        {
            var productModel = JsonConvert.DeserializeObject<ProductModel>(message);
            await MapProductModelToCommandsAndSendHandler(productModel);
        }

        /// <summary>
        /// Após o produto devidamente separado, o fluxo é reponsável por criar comandos de execução
        /// que serão enviados por fluxos divergentes ambos os modelos 
        /// </summary>
        /// <param name="productModel"></param>
        /// <returns></returns>
        private async Task MapProductModelToCommandsAndSendHandler(ProductModel productModel)
        {
            var productAvailabilityCommand = Mapper.MapAvailabilityCommand<ProductModel, ProductAvailabilityCommand>(productModel);

            var productInformationCommand = Mapper.MapInfoCommand<ProductModel, ProductInformationCommand>(productModel);

            await
                Task.WhenAll(
                   _mediator.Send(productAvailabilityCommand),
                   _mediator.Send(productInformationCommand),
                   _mediator.Send(new LogCommand())
                );
        }
    }
}
