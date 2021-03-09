﻿using API.Models;
using MediatR;
using System;

namespace MessageReader.WebJob.Domain
{
    public class ProductInformationCommand : IRequest
    {
        public string SkuEnterprise { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public DateTime DateInsert { get; set; }
        public DateTime DateUpdate { get; set; }
    }
}
