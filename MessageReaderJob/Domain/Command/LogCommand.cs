using MediatR;
using System;

namespace MessageReader.WebJob.Domain.Command
{
    public class LogCommand : IRequest
    {
        public LogCommand()
        {
            IdIdentifier = Guid.NewGuid().ToString();
            DateCreate = DateTime.Now;
        }

        public string IdIdentifier { get; set; }
        public string Message { get; set; }
        public System.Enum TypeProcess { get; set; }
        public DateTime DateCreate { get; set; }
      
    }
}
