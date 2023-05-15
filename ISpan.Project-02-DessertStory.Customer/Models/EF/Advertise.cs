using System;
using System.Collections.Generic;

namespace ISpan.Project_02_DessertStory.Customer.Models.EF
{
    public partial class Advertise
    {
        public int Id { get; set; }
        public string Tcontent { get; set; } = null!;
        public DateTime Tstarttime { get; set; }
        public DateTime Tendtime { get; set; }
    }
}
