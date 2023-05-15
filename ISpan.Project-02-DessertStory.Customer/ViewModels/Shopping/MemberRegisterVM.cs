using JetBrains.Annotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISpan.Project_02_DessertStory.Customer.ViewModels.Shopping
{
    public class MemberRegisterVM
    {
        [Display(Prompt = "姓氏")]
        [Required(ErrorMessage = "請輸入姓氏")]
        public string lastname { get; set; }


        [Display(Prompt = "名字")]
        [Required(ErrorMessage = "請輸入名字")]
        public string firstname { get; set; }

        // todo Regex 包含英數字
        [Display(Prompt = "請設定長度8位以上的帳號")]
        [MinLength(8, ErrorMessage = "帳號長度必須為8位以上")]
        [MaxLength(32, ErrorMessage = "帳號長度必須為32位以下")]
        [Required(ErrorMessage = "請輸入帳號")]
        public string account { get; set; }


        [Display(Prompt = "Email")]
        [EmailAddress(ErrorMessage = "Email格式錯誤")]
        [Required(ErrorMessage = "請輸入Email")]
        public string email { get; set; }

        // todo Regex 包含英數字
        [Display(Prompt = "請設定長度8位以上的密碼")]
        [MinLength(8, ErrorMessage = "密碼長度必須為8位以上")]
        [MaxLength(32, ErrorMessage = "密碼長度必須為32位以下")]
        [Required(ErrorMessage = "請輸入密碼")]
        public string password { get; set; }


        [Display(Prompt = "請再輸入一次密碼")]
        [Compare("password", ErrorMessage = "您輸入的兩次密碼並不相符，請再試一次。")]
        [Required(ErrorMessage = "請再輸入一次密碼")]
        public string confirmPassword { get; set; }

        
        [Display(Prompt = "生日")]
        [MinimumAge(0, ErrorMessage = "生日必須在今天以前")]
        [Required(ErrorMessage = "請輸入生日")]
        public DateTime birthdate { get; set; }


        [Display(Prompt = "性別")]
        [Required(ErrorMessage = "請選擇性別")]
        public string gender { get; set; }
    }


    public class MinimumAgeAttribute : ValidationAttribute
    {
        int _minimumAge;

        public MinimumAgeAttribute(int minimumAge)
        {
            _minimumAge = minimumAge;
        }

        public override bool IsValid(object? value)
        {
            DateTime birthdate;
            if (DateTime.TryParse(value.ToString(), out birthdate))
            {
                bool valid = birthdate.AddYears(_minimumAge) <= DateTime.Today;
                return valid;
            }

            return false;
        }
    }
}
