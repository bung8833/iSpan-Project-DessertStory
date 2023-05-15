using ISpan.Project_02_DessertStory.Customer.Models.EF;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ISpan.Project_02_DessertStory.Customer.ViewModels.Sellers
{
    public class SellerProductsCreateViewModel
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
        public string PictureCreate1 { get; set; }
        [Display(Name = "圖片2")]
        public string PictureCreate2 { get; set; }
        [Display(Name = "圖片3")]
        public string PictureCreate3 { get; set; }
        [Display(Name = "單位")]
        public string ProductUnit { get; set; }
        [Display(Name = "價格")]
        public Decimal UnitPrice { get; set; }
        [Display(Name = "商品數量")]
        public int UnitsInStock { get; set; }
        [Display(Name = "商品描述")]
        public string Description { get; set; }
        [Display(Name = "商品狀態")]
        public bool ProductStatus { get; set; }

        public int SellerId { get; set; }

        
        public IFormFile photoCreate1 { get; set; }
        public IFormFile photoCreate2 { get; set; }
        public IFormFile photoCreate3 { get; set; }
        public List<Category> Category { get; set; }
    }
}
