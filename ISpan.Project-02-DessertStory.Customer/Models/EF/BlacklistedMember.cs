using System;
using System.Collections.Generic;

namespace ISpan.Project_02_DessertStory.Customer.Models.EF
{
    public partial class BlacklistedMember
    {
        public int Id { get; set; }
        public int ItemNo { get; set; }
        public int SellerId { get; set; }
        public int MemberId { get; set; }
        public string? MemberAccount { get; set; }
        public string? Status { get; set; }
    }
}
