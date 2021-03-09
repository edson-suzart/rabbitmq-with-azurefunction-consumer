using MediatR;
using MessageReader.WebJob.Enum;
using System;

namespace MessageReader.WebJob.NotificationModel
{
    public class ProductInformationNotification : INotification
    {
        public string SkuEnterprise { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public DateTime DateInsert { get; set; }
        public DateTime DateUpdate { get; set; }
        public ActionNotification Action { get; set; }
    }
}
