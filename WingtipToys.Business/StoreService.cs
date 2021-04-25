using System;
using System.Collections.Generic;
using WingtipToys.Data;
using WingtipToys.Data.Models;

namespace WingtipToys.Business
{
    public class StoreService : IStoreService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public StoreService(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            if (productRepository == null)
            {
                throw new ArgumentNullException(nameof(productRepository));
            }
            if (categoryRepository == null)
            {
                throw new ArgumentNullException(nameof(categoryRepository));
            }
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }
        public Product CreateProduct(Product product)
        {
            if (product.CategoryID.HasValue && GetCategory(product.CategoryID.Value) == null)
            {
                throw new ApplicationException("Invalid category relation");
            }
            return _productRepository.Create(product);
        }

        public Product UpdateProduct(Product product)
        {
            return _productRepository.Update(product);
        }

        public bool DeleteProduct(int productId)
        {
            return _productRepository.Delete(productId);
        }

        public Product GetProduct(int productId)
        {
            var product = _productRepository.Get(productId);
            if (product.CategoryID.HasValue)
            {
               product.Category = GetCategory(product.CategoryID.Value);
            }
            return product;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            var products = _productRepository.GetAll();
            foreach (var p in products)
            {
                if (p.CategoryID.HasValue)
                {
                    p.Category = GetCategory(p.CategoryID.Value);
                }
            }
            return products;
        }

        public IEnumerable<Product> GetProductByCategoryName(string categoryName)
        {
            var category = _categoryRepository.Get(categoryName);
            if (category == null)
            {
                return new List<Product>(0);
            }
            return GetProductByCategoryId(category.CategoryID);
        }

        public IEnumerable<Product> GetProductByCategoryId(int categoryId)
        {
            var category = _categoryRepository.Get(categoryId);
            if (category == null)
            {
                return new List<Product>(0);
            }
            var products = _productRepository.GetByCategoryId(category.CategoryID);
            foreach (var p in products)
            {
                p.Category = category;
            }
            return products;
        }

        public Category CreateCategory(Category category)
        {
            return _categoryRepository.Create(category);
        }

        public Category UpdateCategory(Category category)
        {
            return _categoryRepository.Update(category);
        }

        public bool CategoryExists(string name)
        {
            return _categoryRepository.Get(name) != null;
        }

        public bool DeleteCategory(int categoryId)
        {
            return _categoryRepository.Delete(categoryId);
        }

        public Category GetCategory(int categoryId)
        {
            return _categoryRepository.Get(categoryId);
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _categoryRepository.GetAll();
        }
    }
}
