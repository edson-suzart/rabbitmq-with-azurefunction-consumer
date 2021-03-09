using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace MessageQueue.WebJob.Infrastructure
{
    public class MongoService : IMongoService
    {
        private readonly IMongoClient _mongoClient;
        private readonly string dataBase = "products";

        public MongoService(IMongoClient mongoClient)
        {
            _mongoClient = mongoClient;
        }

        public async Task Insert<T>(T log, string collectionName)
        {
            try
            {
                var database = _mongoClient.GetDatabase(dataBase);
                var collection = database.GetCollection<T>(collectionName);
                await collection.InsertOneAsync(log);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<T> GetBySkuId<T>(string sku, string collectionName)
        {
            try
            {
                T result;
                var database = _mongoClient.GetDatabase(dataBase);
                var collection = database.GetCollection<T>(collectionName);
                result = (T)await collection.FindAsync(sku);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateBySkuId<T>(T model, string sku, string collectionName)
        {
            try
            {
                var database = _mongoClient.GetDatabase(dataBase);
                var collection = database.GetCollection<T>(collectionName);
                await collection.ReplaceOneAsync(sku, model);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
