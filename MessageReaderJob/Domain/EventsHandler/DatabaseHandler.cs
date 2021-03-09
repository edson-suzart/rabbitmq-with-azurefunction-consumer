using MediatR;
using MessageReader.WebJob.Infrastructure;
using MessageReader.WebJob.NotificationModel;
using System.Threading;
using System.Threading.Tasks;

namespace MessageReader.WebJob.Domain.EventsHandler
{
    public class DatabaseHandler :
        INotificationHandler<ProductAvailabilityNotification>, 
        INotificationHandler<ProductInformationNotification>
    {

        private readonly IMongoService _mongoService;
        private const string availabilityCollection = "products-availabilty";
        private const string informationCollection = "products-information";

        public DatabaseHandler(IMongoService mongoService)
        {
            _mongoService = mongoService;
        }

        public async Task Handle(ProductInformationNotification notification, CancellationToken cancellationToken) 
        {
            var product = await _mongoService.GetBySkuId<ProductInformationNotification>(notification.SkuEnterprise, informationCollection);

            if(product is null)
                await _mongoService.Insert(notification, informationCollection);

            await _mongoService.UpdateBySkuId(notification, notification.SkuEnterprise, informationCollection);

        }

        public async Task Handle(ProductAvailabilityNotification notification, CancellationToken cancellationToken)
        {
            var product = await _mongoService.GetBySkuId<ProductAvailabilityNotification>(notification.SkuPartner, availabilityCollection);

            if(product is null)
                await _mongoService.Insert(notification, availabilityCollection);

            await _mongoService.UpdateBySkuId(notification, notification.SkuPartner, availabilityCollection);
        }
    }
}
