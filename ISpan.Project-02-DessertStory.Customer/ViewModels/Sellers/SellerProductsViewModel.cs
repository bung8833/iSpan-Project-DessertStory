using ISpan.Project_02_DessertStory.Customer.Models.EF;
using System.ComponentModel.DataAnnotations;

namespace ISpan.Project_02_DessertStory.Customer.ViewModels.Sellers
{
    public class SellerProductsViewModel
    {
        private Category _category;
        public int Id { get; set; }
        [Display(Name = "產品名稱")]
        public string ProductName { get; set; }
        [Display(Name = "尺寸")]
        public string ProductSize { get; set; }
        [Display(Name = "類別")]
        public int CategoryId { get; set; }
        [Display(Name = "類別名稱")]
        public string CategoryName { get; set; }
        [Display(Name = "圖片1")]
        public string Picture1 { get; set; }
        [Display(Name = "圖片2")]
        public string Picture2 { get; set; }
        [Display(Name = "圖片3")]
        public string Picture3 { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "${0:N0}")]
        [Display(Name = "價格")]
        public Decimal UnitPrice { get; set; }
        [Display(Name = "商品數量")]
        public int UnitsInStock { get; set; }
        [Display(Name = "商品描述")]
        public string Description { get; set; }
        [Display(Name = "商品狀態")]
        public bool ProductStatus { get; set; }
        
        public int SellerId { get; set; }

        public string txtTag { get; set; }

        [Display(Name = "圖片")]
        public IFormFile photo1 { get; set; }
        public IFormFile photo2 { get; set; }
        public IFormFile photo3 { get; set; }
        public List<Category> Category { get; set; }

    }
}
