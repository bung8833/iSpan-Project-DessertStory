using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ISpan.Project_02_DessertStory.Admin.Models.EF
{
    [ModelMetadataType(typeof(AdministratorMetadata))]
    public partial class Administrator
    {
    }

    internal class AdministratorMetadata
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "姓名不可為空")]
        [Display(Name = "姓名")]
        public string Account { get; set; } = null!;
        [Required(ErrorMessage = "密碼不可為空")]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "密碼格式不符(須包含8-20位英數)")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,20}$", ErrorMessage = "密碼格式不符(須包含8-20位英數)")]
        [Display(Name = "密碼")]
        public string Password { get; set; } = null!;
        [Required(ErrorMessage = "信箱不可為空")]
        [EmailAddress(ErrorMessage = "信箱格式不正確")]
        [Display(Name = "信箱")]
        public string Email { get; set; } = null!;
        [Required(ErrorMessage = "連絡電話不可為空")]
        [RegularExpression(@"^0\d{8,9}$", ErrorMessage = "連絡電話格式不符(須為0開頭，長度為9-10位數字)")]
        [Display(Name = "連絡電話")]
        public string ContactNumber { get; set; } = null!;
        public string? Notes { get; set; }
    }
}
