using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.ModelBinding;
using WingtipToys.Business;
using WingtipToys.Data;
using WingtipToys.Data.Models;

namespace WingtipToys
{
  public partial class ProductDetails : System.Web.UI.Page
  {
      private static readonly IStoreService _service = new StoreService(new InMemoryProductRepository(), new InMemoryCategoryRepository());
        protected void Page_Load(object sender, EventArgs e)
    {

    }

    public IQueryable<Product> GetProduct([RouteData("productId")] int? productId)
    {
      //var _db = new WingtipToys.Models.ProductContext();
      //IQueryable<ProductEntity> query = _db.Products;
      //if (productId.HasValue && productId > 0)
      //{
      //  query = query.Where(p => p.ProductID == productId);
      //}
      //else
      //{
      //  query = null;
      //}
      //return query;
        if (!productId.HasValue || productId.Value == 0)
        {
            return null;
        }
        return new List<Product>(1) { _service.GetProduct(productId.Value) }.AsQueryable();
    }
  }
}