using System;
using System.Collections.Generic;

namespace ISpan.Project_02_DessertStory.Customer.Models.EF
{
    public partial class MemberAddress
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public string ContactName { get; set; } = null!;
        public string ContactNumber { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string ShipZip { get; set; } = null!;
        public string ShipAddress { get; set; } = null!;
        public string? InvoiceZip { get; set; }
        public string? InvoiceAddress { get; set; }
        public string? Notes { get; set; }

        public virtual Member Member { get; set; } = null!;
    }
}
