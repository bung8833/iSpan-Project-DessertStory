using ISpan.Project_02_DessertStory.Customer.Models.EF;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations;

namespace ISpan.Project_02_DessertStory.Customer.ViewModels.Shopping
{
    public class CartItemVM
    {
        public Product product { get; set; }
        public string ProductSize
        {
            get
            {
                return String.IsNullOrWhiteSpace(product.ProductSize) 
                    ? "單一尺寸" 
                    : product.ProductSize;
            }
        }
        
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:N0}")]
        public decimal UnitPrice { get; set; }

        public int Qty { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:N0}")]
        public decimal Subtotal
        {
            get { return this.UnitPrice * this.Qty; }
        }
    }
}
