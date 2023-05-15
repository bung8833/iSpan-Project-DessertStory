using System.ComponentModel.DataAnnotations;

namespace ISpan.Project_02_DessertStory.Customer.ViewModels.Home
{
    public class SellersViewModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "店家名稱")]
        public string StoreName { get; set; }
        [Display(Name = "圖片")]
        public string Picture { get; set; }
        [Display(Name = "主打品項")]
        public string MainProduct { get; set; }
    }
}
