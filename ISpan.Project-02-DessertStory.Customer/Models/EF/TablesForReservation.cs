using System;
using System.Collections.Generic;

namespace ISpan.Project_02_DessertStory.Customer.Models.EF
{
    public partial class TablesForReservation
    {
        public int Id { get; set; }
        public int SellerId { get; set; }
        public int Qty { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime OrderTime { get; set; }
        public string? Notes { get; set; }
    }
}
