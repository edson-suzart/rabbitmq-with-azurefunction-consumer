using API.Models;
using MediatR;
using MessageReader.WebJob.Domain;
using MessageReader.WebJob.Domain.Command;
using MessageReader.WebJob.Mappings;
using MessageReader.WebJob.ModelsConnection;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace MessageReader.Job.Functions
{
    public class RabbitMQTrigger
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _configuration;

        public RabbitMQTrigger(IMediator mediator, IConfiguration configuration)
        {
            _mediator = mediator;
            _configuration = configuration;
        }

        /// <summary>
        /// Recebe o produto na fila e imediatamente o divide em 2 para que as informações do produto
        /// sejam separadas do conceito de disponibilidade e preços
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        [FunctionName("MessageRabbitMQTrigger")]
        public async Task ProcessQueueMessage(
            [RabbitMQTrigger(
                queueName: "product-queue", 
                HostName = "localhost",
                Port = 15672,
                PasswordSetting = "example",
                UserNameSetting = "root")]
                string message)
        {
            var productModel = JsonConvert.DeserializeObject<ProductModel>(message);
            await MapProductModelToCommandsAndSendHandler(productModel);
        }
         
        /// <summary>
        /// Após o produto devidamente separado, o fluxo é reponsável por criar comandos de execução
        /// que serão enviados por fluxos divergentes
        /// </summary>
        /// <param name="productModel"></param>
        /// <returns></returns>
        private async Task MapProductModelToCommandsAndSendHandler(ProductModel productModel)
        {
            var productAvailabilityCommand = 
                Mapper
                    .MapAvailabilityCommand<ProductModel, ProductAvailabilityCommand>(productModel);

            var productInformationCommand = 
                Mapper
                .MapInfoCommand<ProductModel, ProductInformationCommand>(productModel);

            await 
                Task.WhenAll(
                   _mediator.Send(productAvailabilityCommand),
                   _mediator.Send(productInformationCommand),
                   _mediator.Send(new LogCommand())
                );
        }
    }
}