using System.Collections.Generic;
using WingtipToys.Data.Models;

namespace WingtipToys.Business
{
    public interface IStoreService
    {
        Product CreateProduct(Product product);
        Product UpdateProduct(Product product);
        bool DeleteProduct(int productId);
        Product GetProduct(int productId);
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductByCategoryName(string categoryName);
        IEnumerable<Product> GetProductByCategoryId(int categoryId);
        Category CreateCategory(Category category);
        Category UpdateCategory(Category category);
        bool CategoryExists(string name);
        bool DeleteCategory(int categoryId);
        Category GetCategory(int categoryId);
        IEnumerable<Category> GetAllCategories();
        
    }
}