namespace ISpan.Project_02_DessertStory.Customer.ViewModels.Shopping
{
    public class CreateOrderdetailViewModel
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Qty { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Discount { get; set; }
    }
}
