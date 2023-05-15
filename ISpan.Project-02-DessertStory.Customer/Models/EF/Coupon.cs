using System;
using System.Collections.Generic;

namespace ISpan.Project_02_DessertStory.Customer.Models.EF
{
    public partial class Coupon
    {
        public int Id { get; set; }
        public int ItemNo { get; set; }
        public int SellerId { get; set; }
        public string Name { get; set; } = null!;
        public DateTime ValidSince { get; set; }
        public DateTime ValidUntil { get; set; }
        public decimal? DiscountRate { get; set; }
        public decimal? DscountAmount { get; set; }
        public decimal? Threshold { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
    }
}
