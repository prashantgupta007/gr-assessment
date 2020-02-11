using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gr.Data.Entities;

namespace Gr.Data.MongoDB
{
    public class CategoryRepository : ICategoryRepository
    {
        public Task AddCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Category>> GetCategories()
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetCategory(string categoryName)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCategory(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
