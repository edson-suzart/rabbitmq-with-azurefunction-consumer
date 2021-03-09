using System.Threading.Tasks;

namespace MessageReader.WebJob.Infrastructure
{
    public interface IMongoService
    {
        Task Insert<T>(T value, string collectionName);
        Task<T> GetBySkuId<T>(string sku, string collectionName);
        Task UpdateBySkuId<T>(T model, string sku, string collectionName);
    }
}