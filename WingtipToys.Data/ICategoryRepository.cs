using System.Collections.Generic;
using WingtipToys.Data.Models;

namespace WingtipToys.Data
{
    public interface ICategoryRepository
    {
        Category Create(Category category);
        Category Update(Category category);
        bool Delete(int categoryId);
        Category Get(int categoryId);
        Category Get(string categoryName);
        IEnumerable<Category> GetAll();
    }
}