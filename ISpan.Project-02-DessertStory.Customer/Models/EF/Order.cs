using System;
using System.Collections.Generic;

namespace ISpan.Project_02_DessertStory.Customer.Models.EF
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }
        public int MemberId { get; set; }
        public int SellerId { get; set; }
        public decimal TotalPrice { get; set; }
        public string OrderStatus { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string ContactNumber { get; set; } = null!;
        public string ShipZip { get; set; } = null!;
        public string ShipAddress { get; set; } = null!;
        public string? InvoiceZip { get; set; }
        public string? InvoiceAddress { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public decimal ShippingFee { get; set; }
        public string? ShipVia { get; set; }
        public string? PaymentMethod { get; set; }
        public string? Notes { get; set; }

        public virtual Member Member { get; set; } = null!;
        public virtual Seller Seller { get; set; } = null!;
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
