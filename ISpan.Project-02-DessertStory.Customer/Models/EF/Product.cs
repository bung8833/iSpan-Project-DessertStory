using System;
using System.Collections.Generic;

namespace ISpan.Project_02_DessertStory.Customer.Models.EF
{
    public partial class Product
    {
        public Product()
        {
            CartItems = new HashSet<CartItem>();
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int SellerId { get; set; }
        public string ProductName { get; set; } = null!;
        public bool ProductStatus { get; set; }
        public string ProductUnit { get; set; } = null!;
        public string? Picture1 { get; set; }
        public string? Picture2 { get; set; }
        public string? Picture3 { get; set; }
        public string? ProductFlavor { get; set; }
        public string? ProductSize { get; set; }
        public string? Description { get; set; }
        public int UnitsInStock { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsOnOrder { get; set; }
        public DateTime? UploadDate { get; set; }
        public DateTime LastModified { get; set; }

        public virtual Category Category { get; set; } = null!;
        public virtual Seller Seller { get; set; } = null!;
        public virtual ICollection<CartItem> CartItems { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
