using System;
using System.Collections.Generic;

namespace ISpan.Project_02_DessertStory.Customer.Models.EF
{
    public partial class ProductSize
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string SizeName { get; set; } = null!;
    }
}
