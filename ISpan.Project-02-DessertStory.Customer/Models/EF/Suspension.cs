using System;
using System.Collections.Generic;

namespace ISpan.Project_02_DessertStory.Customer.Models.EF
{
    public partial class Suspension
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public DateTime Date { get; set; }
        public string SuspensionType { get; set; } = null!;
        public string? Notes { get; set; }

        public virtual Member Member { get; set; } = null!;
    }
}
