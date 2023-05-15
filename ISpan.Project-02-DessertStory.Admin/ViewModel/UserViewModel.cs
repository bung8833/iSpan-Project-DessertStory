using ISpan.Project_02_DessertStory.Admin.Models.EF;
using X.PagedList;

namespace ISpan.Project_02_DessertStory.Admin.ViewModel
{
    public class UserViewModel
    {
        public IEnumerable<Member> Members { get; set; }
        public IEnumerable<Seller> Sellers { get; set; }

        
    }
}