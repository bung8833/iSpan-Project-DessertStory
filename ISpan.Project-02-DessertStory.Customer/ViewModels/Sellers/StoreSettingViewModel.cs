using ISpan.Project_02_DessertStory.Customer.Models.EF;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;


namespace ISpan.Project_02_DessertStory.Customer.ViewModels.Sellers
{
    public class StoreSettingViewModel
    {
        public int? Id { get; set; }
        public string StoreName { get; set; }

        public string Description { get; set; }
        public string Picture { get; set; }
        
        public IFormFile photo { get; set; }
    }
}
