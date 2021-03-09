using MediatR;
using MessageReader.WebJob.Domain.Command;
using MessageReader.WebJob.Mappings;
using MessageReader.WebJob.NotificationModel;
using System.Threading;
using System.Threading.Tasks;

namespace MessageReader.WebJob.Domain.Handler
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
            var productNofification =  Mapper.MapAvailability<ProductAvailabilityCommand, ProductAvailabilityNotification>(request);

            await _mediator.Publish(productNofification);
            
            return await Task.FromResult(Unit.Value);
        }

        public Task<Unit> Handle(LogCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
