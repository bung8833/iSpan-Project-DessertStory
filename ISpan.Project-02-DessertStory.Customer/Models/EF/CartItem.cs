using System;
using System.Collections.Generic;

namespace ISpan.Project_02_DessertStory.Customer.Models.EF
{
    public partial class CartItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int MemberId { get; set; }
        public int Qty { get; set; }
        public DateTime AddTime { get; set; }
        public string? Notes { get; set; }

        public virtual Member Member { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}
