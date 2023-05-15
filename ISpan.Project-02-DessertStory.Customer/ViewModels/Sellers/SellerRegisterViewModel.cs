using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISpan.Project_02_DessertStory.Customer.ViewModels.Sellers
{

    public class SellerRegisterViewModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Required(ErrorMessage = "請輸入帳號")]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "帳號只能包含字母和數字")]
        [MinLength(8, ErrorMessage = "帳號至少需要八個字符")]
        [Display(Name = "帳號")]
        public string Account { get; set; }
 
        [Required(ErrorMessage = "請輸入密碼")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]+$", ErrorMessage = "密碼至少需包含一個字母和數字")]
        [MinLength(8, ErrorMessage = "密碼至少需要八個字符")]
        [Display(Name = "密碼")]
        public string Password { get; set; }
        
        [Display(Name = "確認密碼")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]+$", ErrorMessage = "密碼至少需包含一個字母和數字")]
        [MinLength(8, ErrorMessage = "密碼至少需要八個字符")]
        [Compare("Password", ErrorMessage = "兩次輸入的密碼必須相符！")]
        public string? PasswordConfirm { get; set; }
        [Required(ErrorMessage = "請輸入身分證字號")]
        [RegularExpression(@"^[A-Z][12]\d{8}$", ErrorMessage = "身分證字號格式錯誤")]
        [Display(Name = "身分證字號")]
        public string IdentityNumber { get; set; }
        [Required(ErrorMessage = "請輸入名字")]
        [Display(Name = "名")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "請輸入姓氏")]
        [Display(Name = "姓")]
        public string LastName { get; set; }

        [EmailAddress(ErrorMessage = "電子信箱格式錯誤")]
        [Required(ErrorMessage = "請輸入電子信箱")]
        [Display(Name = "電子信箱")]
        public string Email { get; set; }
        [Required(ErrorMessage = "請輸入聯絡電話")]
        [Display(Name = "聯絡電話")]
        public string ContactNumber { get; set; }
        [Required(ErrorMessage = "請輸入聯絡地址")]
        [Display(Name = "聯絡地址")]
        public string Address { get; set; }
        [Required(ErrorMessage = "請輸入生日")]
        [Display(Name = "生日")]
        public DateTime BirthDate { get; set; }
        [Required(ErrorMessage = "請輸入店家名稱")]
        [Display(Name = "店家名稱")]
        public string StoreName { get; set; }
        [Required(ErrorMessage = "請輸入店家描述")]
        [Display(Name = "店家描述")]
        
        public string Description { get; set; }
        [Required(ErrorMessage = "請輸入店家圖片")]
        [Display(Name = "店家圖片")]
        public string Picture { get; set; }

        
        [Display(Name = "銀行代號")]
        public string? Bank { get; set; }
        
        [Display(Name = "銀行分支代號")]
        public string? BankBranch { get; set; }
        
        [Display(Name = "銀行戶名")]
        public string? BankName { get; set; }
        
        [Display(Name = "銀行帳號")]
        public string? BankAccount { get; set; }

        [NotMapped]
        public IFormFile photo { get; set; }


    }
}
