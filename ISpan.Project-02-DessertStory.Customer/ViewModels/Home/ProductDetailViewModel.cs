using System.ComponentModel.DataAnnotations;

namespace ISpan.Project_02_DessertStory.Customer.ViewModels.Home
{
    public class ProductDetailViewModel
    {
        public int Id { get; set; }
        public string Picture1 { get; set; }
        public string Picture2 { get; set; }
        public string Picture3 { get; set; }
        public string ProductName { get; set; }
        public string ProductSize { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "${0:N0}")]
        public decimal UnitPrice { get; set; }
        public string Description { get; set; }
        public int OrderQuantity { get; set; }

        public IFormFile Photo1 { get; set; }
        public IFormFile Photo2 { get; set; }
        public IFormFile Photo3 { get; set; }
    }
}
