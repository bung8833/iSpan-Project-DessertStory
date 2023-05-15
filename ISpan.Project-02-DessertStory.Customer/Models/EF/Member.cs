using System;
using System.Collections.Generic;

namespace ISpan.Project_02_DessertStory.Customer.Models.EF
{
    public partial class Member
    {
        public Member()
        {
            CartItems = new HashSet<CartItem>();
            MemberAddresses = new HashSet<MemberAddress>();
            Orders = new HashSet<Order>();
            Suspensions = new HashSet<Suspension>();
        }

        public int Id { get; set; }
        public string Account { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string IdentityNumber { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; } = null!;
        public string Email { get; set; } = null!;
        public bool SuspensionStatus { get; set; }
        public string Mobile { get; set; } = null!;
        public string? Tel { get; set; }
        public string? Country { get; set; }
        public string? Zip { get; set; }
        public string? City { get; set; }
        public string? District { get; set; }
        public string? Address { get; set; }
        public string? InvoiceCarrier { get; set; }
        public string? Picture { get; set; }
        public string? SuspensionReason { get; set; }
        public string? Notes { get; set; }

        public virtual ICollection<CartItem> CartItems { get; set; }
        public virtual ICollection<MemberAddress> MemberAddresses { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Suspension> Suspensions { get; set; }
    }
}
