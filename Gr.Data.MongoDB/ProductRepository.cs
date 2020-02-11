using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gr.Data.Entities;

namespace Gr.Data.MongoDB
{
    public class ProductRepository : IProductRepository
    {
        public Task AddProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public Task DeleteProduct(int productId)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetProduct(string productName)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetProducts()
        {
            throw new NotImplementedException();
        }

        public Task UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
