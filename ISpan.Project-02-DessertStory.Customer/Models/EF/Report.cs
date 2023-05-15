using System;
using System.Collections.Generic;

namespace ISpan.Project_02_DessertStory.Customer.Models.EF
{
    public partial class Report
    {
        public int Id { get; set; }
        public string? Reporter { get; set; }
        public string? Reportreason { get; set; }
        public string? Reportcategory { get; set; }
        public string? Detail { get; set; }
    }
}
