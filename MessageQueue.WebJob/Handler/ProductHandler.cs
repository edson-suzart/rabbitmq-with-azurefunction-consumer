using MediatR;
using MessageQueue.WebJob.Domain.Command;
using MessageQueue.WebJob.Mappings;
using MessageQueue.WebJob.NotificationModel;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MessageQueue.WebJob.Domain.Handler
{
    public class ProductHandler :
        IRequestHandler<ProductAvailabilityCommand>,
        IRequestHandler<ProductInformationCommand>,
        IRequestHandler<LogCommand>
    {
        private readonly IMediator _mediator;

        public ProductHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Unit> Handle(ProductInformationCommand request, CancellationToken cancellationToken)
        {
            var productCommand = Mapper.MapInformation<ProductInformationCommand, ProductInformationNotification>(request);

            await _mediator.Publish(productCommand);

            return await Task.FromResult(Unit.Value);
        }

        public async Task<Unit> Handle(ProductAvailabilityCommand request, CancellationToken cancellationToken)
        {
            var productNofification = Mapper.MapAvailability<ProductAvailabilityCommand, ProductAvailabilityNotification>(request);

            await _mediator.Publish(productNofification);

            return await Task.FromResult(Unit.Value);
        }

        public async Task<Unit> Handle(LogCommand log, CancellationToken cancellationToken)
        {
            log.Message = "Produto manipulado!";

            Console.WriteLine($"Log momentâneo para testes. Dados: {log}");

            return await Task.FromResult(Unit.Value);
        }
    }
}
