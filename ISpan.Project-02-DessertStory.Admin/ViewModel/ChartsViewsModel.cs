using ISpan.Project_02_DessertStory.Admin.Models.EF;

namespace ISpan.Project_02_DessertStory.Admin.ViewModel
{
    public class ChartsViewsModel
    {
        public IEnumerable<Member> Members { get; set; }
        public IEnumerable<Seller> Sellers { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Order> Orders { get; set; }
    }
}
