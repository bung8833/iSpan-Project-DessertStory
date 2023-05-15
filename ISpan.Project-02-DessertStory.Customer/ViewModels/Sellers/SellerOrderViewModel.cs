using System.ComponentModel.DataAnnotations;

namespace ISpan.Project_02_DessertStory.Customer.ViewModels.Sellers
{
    public class SellerOrderViewModel
    {

        public string KeywordsSearch { get; set; }

        public int OrderId { get; set; }
        public int SellerId { get; set; }
        public int MemberId { get; set; }
        [Display(Name = "名")]
        public string MemberFirstName { get; set; }
        [Display(Name = "姓")]
        public string MemberLastName { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "${0:N0}")]
        [Display(Name = "訂單金額")]
        public decimal TotalPrice { get; set; }
        [Display(Name = "連絡電話")]
        public string ContectNumber { get; set; }
        [Display(Name = "寄送地址")]
        public string Address { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "訂單日期")]
        public DateTime OrderDate { get; set; }
        [Display(Name = "訂單狀態")]
        public string OrderStatus { get; set; }
        [Display(Name = "付款方式")]
        public string PaymentMethod { get; set; }
        [Display(Name = "物流方式")]
        public string ShipVia { get; set; }

        public string SelectedOrderStatus { get; set; }
        public string SelectedPaymentMethod { get; set; }
        public string SelectedShipVia { get; set; }

        public string DateStart { get; set; }
        public string DateEnd { get; set; }

    }
}
