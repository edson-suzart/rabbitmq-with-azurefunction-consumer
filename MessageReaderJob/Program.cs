using MediatR;
using MessageReader.WebJob.Infrastructure;
using MessageReader.WebJob.ModelsConnection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MongoDB.Driver;
using RabbitMQ.Client;
using System;

namespace MessageReader.WebJob
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = new HostBuilder();
            
            builder.ConfigureWebJobs(b =>
            {
                b.AddAzureStorageCoreServices();
                b.AddAzureStorage();
                b.AddTimers();
                b.AddRabbitMQ();
            });

            builder.RunConsoleAsync();

            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false)
                .Build();
            
            IServiceCollection services = new ServiceCollection();

            services
                .AddMediatR(typeof(Program))
                .AddScoped<IMongoService, MongoService>()
                .AddSingleton<IMongoClient, MongoClient>(client => 
                    new MongoClient(configuration.GetSection("AppSettings:Mongo").Get<Mongo>().GetConnectionString()));

            Console.WriteLine("Job iniciado. Pronto para ler mensagens! ");
        }
    }
}