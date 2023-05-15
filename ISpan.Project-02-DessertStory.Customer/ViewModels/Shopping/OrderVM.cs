namespace ISpan.Project_02_DessertStory.Customer.ViewModels.Shopping
{
    public class OrderVM
    {
        public OrderVM() 
        {
            OrderDetail = new List<OrderDetailVM>();
        }
        public int MemberId { get; set; }
        public int SellerId { get; set; }
        public decimal TotalPrice { get; set; }
        public List<OrderDetailVM> OrderDetail { get; set; }
    }
}
