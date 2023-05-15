using ISpan.Project_02_DessertStory.Customer.Models.EF;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace ISpan.Project_02_DessertStory.Customer.ViewModels.Home
{
    public class ProductsQuertServiceViewModel
    {
        private Product _product;
        private Category _category;
        private Seller _seller;
        public ProductsQuertServiceViewModel()
        {
            _product = new Product();
            _category = new Category();
            _seller = new Seller();
        }
        public int ProductId { get => _product.Id; set => _product.Id = value; }
        public int CategoryId { get => _category.Id; set => _category.Id = value; }
        public string CategoryName { get => _category.Name; set => _category.Name = value; }
        public int SellerId { get => _product.SellerId; set => _product.SellerId = value; }

        public string StoreName { get => _seller.StoreName; set => _seller.StoreName = value; }
        public string SellerDescription { get => _seller.Description; set => _seller.Description = value; }
        public string ProductName { get => _product.ProductName; set => _product.ProductName = value; }
        public decimal UnitPrice { get => _product.UnitPrice; set => _product.UnitPrice = value; }
        public string ProductDescription { get => _product.Description; set => _product.Description = value; }
        public string Picture1 { get => _product.Picture1; set => _product.Picture1 = value; }

        public string Picture2 { get => _product.Picture2; set => _product.Picture2 = value; }

        public string Picture3 { get => _product.Picture3; set => _product.Picture3 = value; }

        public Category category { get => _category; set => _category = value; }


    }
}
