using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations;

namespace ISpan.Project_02_DessertStory.Customer.ViewModels.Shopping
{
    public class MemberOrderDetailVM
    {
        public string ProductName { get; set; }
        public int Qty { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:N0}")]
        public decimal Subtotal { get; set; }
        public string Size { get; set; }
    }
}
