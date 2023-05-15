using System.ComponentModel.DataAnnotations;

namespace ISpan.Project_02_DessertStory.Customer.ViewModels.Sellers
{
    public class SellerOrderDetailViewModel
    {
        [Display(Name = "訂單編號")]
        public int OrderId { get; set; }
        [Display(Name = "訂單明細編號")]
        public int OrderDetailId { get; set; }
        [Display(Name = "產品編號")]
        public int ProductId { get; set; }
        [Display(Name = "產品名稱")]
        public string ProductName { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "${0:N0}")]
        [Display(Name = "單價")]
        public decimal? UnitPrice { get; set; }
        [Display(Name = "數量")]
        public int? Quantity { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "${0:N0}")]
        [Display(Name = "小計")]
        public decimal? SubTotal { get; set; }
    }
}
