using System;
using System.Collections.Generic;
using System.Linq;
using WingtipToys.Data.Models;

namespace WingtipToys.Data
{
    public class InMemoryCategoryRepository : ICategoryRepository
    {
        public Category Create(Category category)
        {
            lock (_sync)
            {
                if (_storage.Any(x => x.CategoryName.Equals(category.CategoryName, StringComparison.InvariantCultureIgnoreCase)))
                {
                    throw new ApplicationException("Category name violation. Category with specified name already exists.");
                }
                if (category.CategoryID != default(int))
                {
                    if (_storage.Any(x => x.CategoryID.Equals(category.CategoryID)))
                    {
                        return null;
                    }
                    category.CategoryID = _storage.Count + 1;
                }
                _storage.Add(category);
            }
            return category;
        }

        public Category Update(Category category)
        {
            lock (_sync)
            {
                if (!_storage.Any(x => x.CategoryID.Equals(category.CategoryID)))
                {
                    return null;
                }
                _storage.RemoveWhere(x => x.CategoryID.Equals(category.CategoryID));
                _storage.Add(category);
            }
            return category;
        }

        public bool Delete(int categoryId)
        {
            return _storage.RemoveWhere(x => x.CategoryID.Equals(categoryId)) > 0;
        }

        public Category Get(int categoryId)
        {
            return _storage.FirstOrDefault(x => x.CategoryID.Equals(categoryId));
        }

        public Category Get(string categoryName)
        {
            return _storage.FirstOrDefault(
                x => x.CategoryName.Equals(categoryName, StringComparison.InvariantCultureIgnoreCase));
        }

        public IEnumerable<Category> GetAll()
        {
            return _storage.ToList();
        }

        private static readonly object _sync = new object();
        private static readonly HashSet<Category> _storage = new HashSet<Category> {
            new Category
            {
                CategoryID = 1,
                CategoryName = "Cars"
            },
            new Category
            {
                CategoryID = 2,
                CategoryName = "Planes"
            },
            new Category
            {
                CategoryID = 3,
                CategoryName = "Trucks"
            },
            new Category
            {
                CategoryID = 4,
                CategoryName = "Boats"
            },
            new Category
            {
                CategoryID = 5,
                CategoryName = "Rockets"
            }
        };
    }
}
