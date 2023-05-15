using ISpan.Project_02_DessertStory.Customer.Models.EF;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace ISpan.Project_02_DessertStory.Customer.ViewModels.Home
{
    public class ProductsQuertServiceApiVm
    {
        public int productId { get; set; }
        public int categoryId { get; set; }
        public string categoryName { get; set; }
        public int sellerId { get; set; }
        public string storeName { get; set; }
        public string sellerDescription { get; set; }
        public string productName { get; set; }
        public decimal unitPrice { get; set; }
        public string productDescription { get; set; }
        public string picture1 { get; set; }
        public string picture2 { get; set; }
        public string picture3 { get; set; }
        public Category category { get; set; }
    }
}
