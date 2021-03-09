using API.Models;
using System.Threading.Tasks;

namespace API.Service
{
    public interface IProductService
    {
        void SendProductModelQueue(ProductModel productModel);
    }
}