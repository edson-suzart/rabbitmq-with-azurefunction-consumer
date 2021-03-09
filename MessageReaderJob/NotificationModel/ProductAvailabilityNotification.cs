using MediatR;
using MessageReader.WebJob.Enum;
using System;

namespace MessageReader.WebJob.NotificationModel
{
    public class ProductAvailabilityNotification : INotification
    {
        public string SkuPartner { get; set; }
        public decimal Price { get; set; }
        public bool Availability { get; set; }
        public DateTime DateInsert { get; set; }
        public DateTime DateUpdate { get; set; }
        public ActionNotification Action { get; set; }
    }
}
