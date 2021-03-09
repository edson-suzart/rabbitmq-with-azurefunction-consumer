using MediatR;
using MessageQueue.WebJob;
using MessageQueue.WebJob.Infrastructure;
using MessageQueue.WebJob.ModelsConnection;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using System;

[assembly: WebJobsStartup(typeof(Startup))]
namespace MessageQueue.WebJob
{
    public sealed class Startup : IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder builder)
        {
            var configuration = new ConfigurationBuilder()
                   .SetBasePath(Environment.CurrentDirectory)
                   .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
                   .AddEnvironmentVariables()
                   .Build();

            ConfigureServices(builder.Services, configuration);
        }

        private void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddMediatR(typeof(Startup))
                .AddScoped<IMongoService, MongoService>()
                .AddSingleton<IMediator, Mediator>()
                .AddSingleton<IMongoClient, MongoClient>(client =>
                    new MongoClient(configuration.GetSection("AppSettings:Mongo").Get<Mongo>().GetConnectionString()));
        }
    }
}