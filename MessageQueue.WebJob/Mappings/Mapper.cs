using MessageQueue.Models;
using MessageQueue.WebJob.Domain;
using MessageQueue.WebJob.NotificationModel;

namespace MessageQueue.WebJob.Mappings
{
    public static class Mapper
    {
        public static Tout MapAvailabilityCommand<Tin, Tout>(Tin entry)
            where Tin : ProductModel
            where Tout : ProductAvailabilityCommand,
                new() => new Tout
                {
                    SkuPartner = entry.SkuPartner,
                    Price = entry.Price,
                    Availability = entry.Availability,
                    DateInsert = entry.DateInsert,
                    DateUpdate = entry.DateUpdate
                };

        public static Tout MapInfoCommand<Tin, Tout>(Tin entry)
          where Tin : ProductModel
          where Tout : ProductInformationCommand,
              new() => new Tout
              {
                  SkuEnterprise = entry.SkuPartner,
                  Description = entry.Description,
                  Image = entry.Image,
                  DateInsert = entry.DateInsert,
                  DateUpdate = entry.DateUpdate
              };

        public static Tout MapAvailability<Tin, Tout>(Tin entry)
            where Tin : ProductAvailabilityCommand
            where Tout : ProductAvailabilityNotification,
                new() => new Tout
                {
                    SkuPartner = entry.SkuPartner,
                    Price = entry.Price,
                    Availability = entry.Availability,
                    DateInsert = entry.DateInsert,
                    DateUpdate = entry.DateUpdate
                };

        public static Tout MapInformation<Tin, Tout>(Tin entry)
            where Tin : ProductInformationCommand
            where Tout : ProductInformationNotification,
                new() => new Tout
                {
                    SkuEnterprise = entry.SkuEnterprise,
                    Description = entry.Description,
                    Image = entry.Image,
                    DateInsert = entry.DateInsert,
                    DateUpdate = entry.DateUpdate
                };
    }
}
