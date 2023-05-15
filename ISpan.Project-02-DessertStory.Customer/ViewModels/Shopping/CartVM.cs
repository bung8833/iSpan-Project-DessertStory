using ISpan.Project_02_DessertStory.Customer.Models.EF;

namespace ISpan.Project_02_DessertStory.Customer.ViewModels.Shopping
{
    public class CartVM
    {
        public Member member { get; set; }
        public Seller seller { get; set; }

        public List<CartItemVM> CartItemVMs { get; set; } = new List<CartItemVM>();
    }
}
