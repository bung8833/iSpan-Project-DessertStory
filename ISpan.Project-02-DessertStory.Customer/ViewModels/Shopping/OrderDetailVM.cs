namespace ISpan.Project_02_DessertStory.Customer.ViewModels.Shopping
{
    public class OrderDetailVM
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Qty { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Subtotal { get ; set; }
        public decimal Discount { get; set; }
    }
}
