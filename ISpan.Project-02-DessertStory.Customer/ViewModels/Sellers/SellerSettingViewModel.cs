using ISpan.Project_02_DessertStory.Customer.Models.EF;
using System.ComponentModel.DataAnnotations;

namespace ISpan.Project_02_DessertStory.Customer.ViewModels.Sellers
{
    public class SellerSettingViewModel
    {
        public int Id { get; set; }
        public string Account { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }
        [Required]
        public string ContactNumber { get; set; }
        [Required]
        public string Email { get; set; }

        public List<Seller> Seller { get; set; }
    }
}
