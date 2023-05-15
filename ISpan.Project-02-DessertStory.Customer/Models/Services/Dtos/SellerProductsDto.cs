using ISpan.Project_02_DessertStory.Customer.Models.EF;
using ISpan.Project_02_DessertStory.Customer.ViewModels.Sellers;

namespace ISpan.Project_02_DessertStory.Customer.Models.Services.Dtos
{
    public class SellerProductsDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductSize { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Picture1 { get; set; }
        public string Picture2 { get; set; }
        public string Picture3 { get; set; }
        public string Description { get; set; }
        public Decimal UnitPrice { get; set; }
        public bool ProductStatus { get; set; }
        public int UnitsInStock { get; set; }

        public int SellerId { get; set; }
        public List<Category> Category { get; set; }
    }
    public static class SellerProductsServiceExpansion
    {
        public static SellerProductsViewModel ToSellerProductsViewModel(this SellerProductsDto dto)
        {
            return new SellerProductsViewModel
            {
                Id = dto.Id,
                SellerId = dto.SellerId,
                ProductStatus = dto.ProductStatus,
                ProductName = dto.ProductName,
                ProductSize = dto.ProductSize,
                Picture1 = dto.Picture1,
                Picture2 = dto.Picture2,
                Picture3 = dto.Picture3,
                CategoryName = dto.CategoryName,
                Description = dto.Description,
                UnitPrice = dto.UnitPrice,
                UnitsInStock = dto.UnitsInStock,
                Category = dto.Category

            };
        }
    }
}