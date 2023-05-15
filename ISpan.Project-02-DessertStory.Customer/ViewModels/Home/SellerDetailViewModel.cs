using System.ComponentModel.DataAnnotations;

namespace ISpan.Project_02_DessertStory.Customer.ViewModels.Home
{
    public class SellerDetailViewModel
    {
        [Display(Name = "賣家編號")]
        public int Id { get; set; }
        [Display(Name = "賣場名稱")]
        public string StoreName { get; set; }
        [Display(Name = "賣場圖片")]
        public string Picture { get; set; }
        [Display(Name = "賣場描述")]
        public string Description { get; set; }
        [Display(Name = "賣家地址")]
        public string Address { get; set; }
        [Display(Name = "聯絡電話")]
        public string Phone { get; set; }

     
    }
}
