using Newtonsoft.Json;
using System;

namespace MessageQueue.Models
{
    public class ProductModel
    {
        [JsonProperty(PropertyName = "skuPartner")]
        public string SkuPartner { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "image")]
        public string Image { get; set; }

        [JsonProperty(PropertyName = "price")]
        public decimal Price { get; set; }

        [JsonProperty(PropertyName = "availability")]
        public bool Availability { get; set; }

        [JsonProperty(PropertyName = "dateInsert")]
        public DateTime DateInsert { get; set; }

        [JsonProperty(PropertyName = "dateUpdate")]
        public DateTime DateUpdate { get; set; }
    }
}
