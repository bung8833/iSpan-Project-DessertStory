using System;
using System.Collections.Generic;

namespace ISpan.Project_02_DessertStory.Customer.Models.EF
{
    public partial class LoginHistory
    {
        public int Id { get; set; }
        public string Account { get; set; } = null!;
        public DateTime LoginDate { get; set; }
        public bool LoginState { get; set; }
    }
}
