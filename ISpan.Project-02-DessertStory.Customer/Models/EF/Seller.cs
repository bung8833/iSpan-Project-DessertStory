using System;
using System.Collections.Generic;

namespace ISpan.Project_02_DessertStory.Customer.Models.EF
{
    public partial class Seller
    {
        public Seller()
        {
            Orders = new HashSet<Order>();
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Account { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? PasswordSalt { get; set; }
        public string IdentityNumber { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string ContactNumber { get; set; } = null!;
        public string Address { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public string StoreName { get; set; } = null!;
        public string? Description { get; set; }
        public string? Picture { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime LastLogin { get; set; }
        public bool WasSuspended { get; set; }
        public bool SuspensionStatus { get; set; }
        public string? SuspensionReason { get; set; }
        public string? Bank { get; set; }
        public string? BankBranch { get; set; }
        public string? BankName { get; set; }
        public string? BankAccount { get; set; }
        public bool? EmailStatus { get; set; }
        public string? EmailToken { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
