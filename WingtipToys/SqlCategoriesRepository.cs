using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WingtipToys.Data;

namespace WingtipToys
{
    public class SqlCategoryRepository : ICategoryRepository
    {
        public Category Create(Category category)
        {
            
            using (var ctx = new WingtipEntities())
            {
                var added = ctx.Categories.Add(category);
                ctx.SaveChanges();
                return added;
            }

        }

        public bool Delete(int categoryId)
        {
            using (var ctx = new WingtipEntities())
            {
                var existing = ctx.Categories.SingleOrDefault(x => x.CategoryID == categoryId);
                if (existing == null)
                {
                    return false;
                }
                ctx.Categories.Remove(existing);
                ctx.SaveChanges();
                return true;
            }

        }

        public Category Get(string categoryName)
        {
            using (var ctx = new WingtipEntities())
            {
                return ctx.Categories.SingleOrDefault(x => x.CategoryName.Equals(categoryName, StringComparison.InvariantCultureIgnoreCase));
            }


        }

        public Category Get(int categoryId)
        {
            using (var ctx = new WingtipEntities())
            {
                return ctx.Categories.SingleOrDefault(x => x.CategoryID == categoryId);
            }

        }

        public IEnumerable<Category> GetAll()
        {
            using (var ctx = new WingtipEntities())
            {
                return ctx.Categories.ToList();
            }

        }

        public Category Update(Category category)
        {
            using (var ctx = new WingtipEntities())
            {
                var existing = ctx.Categories.SingleOrDefault(x => x.CategoryID == category.CategoryID);
                if (existing == null)
                {
                    return null;
                }
                existing.Description = category.Description;
                existing.CategoryName = category.CategoryName;
                ctx.SaveChanges();
                return existing;
            }

        }

        Data.Models.Category ICategoryRepository.Create(Data.Models.Category category)
        {
            throw new NotImplementedException();
        }

        Data.Models.Category ICategoryRepository.Get(int categoryId)
        {
            throw new NotImplementedException();
        }

        Data.Models.Category ICategoryRepository.Get(string categoryName)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Data.Models.Category> ICategoryRepository.GetAll()
        {
            throw new NotImplementedException();
        }

        Data.Models.Category ICategoryRepository.Update(Data.Models.Category category)
        {
            throw new NotImplementedException();
        }
    }

}