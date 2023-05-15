using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace ISpan.Project_02_DessertStory.Customer.ViewModels.Shopping
{
    public class MemberLoginVM
    {
        [Required(ErrorMessage = "請輸入帳號")]
        public string? txtAccount { get; set; }

        [Required(ErrorMessage = "請輸入密碼")]
        public string? txtPassword { get; set; }
    }
}
