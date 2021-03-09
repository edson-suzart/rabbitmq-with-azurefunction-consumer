using MongoDB.Driver;
using System.Threading.Tasks;

namespace MessageReader.WebJob.Infrastructure
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
            var database = _mongoClient.GetDatabase(dataBase);
            var collection = database.GetCollection<T>(collectionName);
            await collection.InsertOneAsync(log);
        }

        public async Task<T> GetBySkuId<T>(string sku, string collectionName) 
        {
            T result;
            var database = _mongoClient.GetDatabase(dataBase);
            var collection = database.GetCollection<T>(collectionName);
            result = (T)await collection.FindAsync(sku);
            return result;
        }

        public async Task UpdateBySkuId<T>(T model, string sku, string collectionName)
        {
            var database = _mongoClient.GetDatabase(dataBase);
            var collection = database.GetCollection<T>(collectionName);
            await collection.ReplaceOneAsync(sku, model);
        }
    }
}
