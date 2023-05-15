using System;
using System.Collections.Generic;

namespace ISpan.Project_02_DessertStory.Customer.Models.EF
{
    public partial class ProductFlavor
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string FlavorName { get; set; } = null!;
    }
}
