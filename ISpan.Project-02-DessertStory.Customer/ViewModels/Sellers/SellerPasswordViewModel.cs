using System.ComponentModel.DataAnnotations;

namespace ISpan.Project_02_DessertStory.Customer.ViewModels.Sellers
{
    public class SellerPasswordViewModel
    {
        public int Id { get; set; }

        //public string SellerOldPassword { get; set; }
        [Required(ErrorMessage = "請輸入密碼")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]+$", ErrorMessage = "密碼至少需包含一個字母和數字")]
        [MinLength(8, ErrorMessage = "密碼至少需要八個字符")]
        [Display(Name = "新密碼")]
        public string SellerNewPassword { get; set; }

        [Required(ErrorMessage = "請輸入確認密碼")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]+$", ErrorMessage = "密碼至少需包含一個字母和數字")]
        [MinLength(8, ErrorMessage = "密碼至少需要八個字符")]
        [Compare("SellerNewPassword", ErrorMessage = "兩次輸入的密碼必須相符！")]
        [Display(Name = "確認密碼")]
        public string SellerNewConfirmPassword { get; set; }
    }
}
