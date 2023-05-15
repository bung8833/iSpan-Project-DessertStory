using System.ComponentModel.DataAnnotations;

namespace ISpan.Project_02_DessertStory.Customer.ViewModels.Shopping
{
    public class MemberOrderVM
    {
        public int OrderId { get; set; }
        public string StoreName { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:N0}")]
        public decimal TotalPrice { get; set; }
        
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime OrderDate { get; set; }
        public string OrderStatus { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:N0}")]
        public decimal ShippingFee { get; set; }
        public string? PaymentMethod { get; set; }

        //public List<MemberOrderDetailVM> MemberOrderDetailVMs { get; set; }
        //    = new List<MemberOrderDetailVM>();
    }
}
