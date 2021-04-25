using System;
using System.Web.UI.WebControls;
using WingtipToys.Business;
using WingtipToys.Data;
using WingtipToys.Data.Models;

namespace WingtipToys
{
    public partial class CategoryCreate : System.Web.UI.Page
    {
        private static readonly IStoreService _service = new StoreService(new InMemoryProductRepository(), new InMemoryCategoryRepository());

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnPreRender(EventArgs e)
        {
            if (IsPostBack && IsValid)
            {
                CreateCategoryForm.Visible = false;
                SuccessBlock.Visible = true;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                var category = new Category
                {
                    CategoryName = Name.Text,
                    Description = Description.Value
                };
                var created = _service.CreateCategory(category);
                MesageCategoryName.Text = created.CategoryName;
            }
        }

        protected void ValidateUnique(object source, ServerValidateEventArgs args)
        {
            args.IsValid = !_service.CategoryExists(args.Value);
        }
    }
}