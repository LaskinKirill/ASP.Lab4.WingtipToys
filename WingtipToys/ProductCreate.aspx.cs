using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WingtipToys.Business;
using WingtipToys.Data;
using WingtipToys.Data.Models;

namespace WingtipToys
{
    public partial class ProductCreate : System.Web.UI.Page
    {
        private static readonly IStoreService _service = new StoreService(new InMemoryProductRepository(), new InMemoryCategoryRepository());
        private readonly HttpClient _httpClient = new HttpClient() {Timeout = TimeSpan.FromSeconds(5)};

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnPreRender(EventArgs e)
        {
            if (IsPostBack && IsValid)
            {
                CreateProductForm.Visible = false;
                SuccessBlock.Visible = true;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                var product = new Product
                {
                    ProductName = Name.Text,
                    UnitPrice = (double?)decimal.Parse(PriceInput.Text),
                    ImagePath= ImageUrlInput.Text,
                    CategoryID = int.Parse(CategoryList.SelectedValue),
                    Description = Description.Value
                };
                var created = _service.CreateProduct(product);
                MesageProductName.Text = created.ProductName;
                MessageProductID.Text = created.ProductID.ToString();
            }
        }

        protected void ValidationImageExistence(object source, ServerValidateEventArgs args)
        {
            var request = new HttpRequestMessage(HttpMethod.Head, args.Value);
            try
            {
                using (var response = AsyncHelper.RunSync(() => _httpClient.SendAsync(request)))
                {
                    args.IsValid = response.IsSuccessStatusCode && response.Content.Headers.ContentType.MediaType.StartsWith("image/");
                }
            }
            catch (HttpRequestException)
            {
                args.IsValid = false;
            }
        }

        public IQueryable<Category> GetCategories()
        {
            return (IQueryable<Category>)_service.GetAllCategories().AsQueryable();
        }
    }
}