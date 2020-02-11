using System.Collections.Generic;
using System.Threading.Tasks;
using Gr.Data.Entities;

namespace Gr.Data
{
    public interface IProductRepository
    {
        Task<Product> GetProduct(string productName);
        Task<IEnumerable<Product>> GetProducts();
        Task AddProduct(Product product);
        Task UpdateProduct(Product product);
        Task DeleteProduct(int productId);
    }
}
