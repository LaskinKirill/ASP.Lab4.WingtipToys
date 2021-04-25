using System.Collections.Generic;
using WingtipToys.Data.Models;

namespace WingtipToys.Data
{
    public interface IProductRepository
    {
        Product Create(Product product);
        Product Update(Product product);
        bool Delete(int productId);
        Product Get(int productId);
        IEnumerable<Product> GetByCategoryId(int categoryId);
        IEnumerable<Product> GetAll();
    }
}