using System.Collections.Generic;
using System.Threading.Tasks;
using Gr.Data.Entities;

namespace Gr.Data
{
    public interface ICategoryRepository
    {
        Task<Category> GetCategory(string categoryName);
        Task<IEnumerable<Category>> GetCategories();
        Task AddCategory(Category category);
        Task UpdateCategory(Category category);
        Task DeleteCategory(int categoryId);
    }
}
