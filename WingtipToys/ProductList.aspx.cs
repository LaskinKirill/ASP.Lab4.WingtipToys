using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.ModelBinding;
using System.Web.Routing;
using WingtipToys.Business;
using WingtipToys.Data;
using WingtipToys.Data.Models;

namespace WingtipToys
{
  public partial class ProductList : System.Web.UI.Page
  {

    private static readonly IStoreService _service = new StoreService(new InMemoryProductRepository(), new InMemoryCategoryRepository());
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public IQueryable<Product> GetProducts([QueryString("id")] int? categoryId, [RouteData] string categoryName)
    {
        if (categoryId.HasValue && categoryId > 0)
        {
            return _service.GetProductByCategoryId(categoryId.Value).AsQueryable();
        }

        if (!string.IsNullOrEmpty(categoryName))
        {
            return _service.GetProductByCategoryName(categoryName).AsQueryable();
        }
        return _service.GetAllProducts().AsQueryable();
    }

        protected void productList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}