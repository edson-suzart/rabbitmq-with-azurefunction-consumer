using MediatR;
using System;

namespace MessageQueue.WebJob.Domain
{
    public class ProductAvailabilityCommand : IRequest
    {
        public string SkuPartner { get; set; }
        public decimal Price { get; set; }
        public bool Availability { get; set; }
        public DateTime DateInsert { get; set; }
        public DateTime DateUpdate { get; set; }

    }
}
