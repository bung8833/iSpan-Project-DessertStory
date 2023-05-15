namespace ISpan.Project_02_DessertStory.Customer.ViewModels.Shopping
{
    public class CreateOrderViewModel
    {
        public CreateOrderViewModel()
        {
            OrderDetail = new List<CreateOrderdetailViewModel>();
        }

        public int MemberId { get; set; }
        public int SellerId { get; set; }
        public decimal TotalPrice { get; set; }
        public string OrderStatus { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string ContactNumber { get; set; } = null!;
        public string ShipZip { get; set; } = null!;
        public string ShipAddress { get; set; } = null!;
        public DateTime OrderDate { get; set; }
        public decimal ShippingFee { get; set; }
        public string? ShipVia { get; set; }
        public string? PaymentMethod { get; set; }
        public string? Notes { get; set; }
        public List<CreateOrderdetailViewModel> OrderDetail { get; set; }
    }
}
