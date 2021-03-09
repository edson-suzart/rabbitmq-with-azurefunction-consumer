using System;
using System.Collections.Generic;
using System.Text;

namespace MessageReader.WebJob.ModelsConnection
{
    public class Mongo
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string User { get; set; }
        public string Password { get; set; }

        public string GetConnectionString() =>
            $@"mongodb://{User}:{Password}@{Host}:{Port}";
    }
}
