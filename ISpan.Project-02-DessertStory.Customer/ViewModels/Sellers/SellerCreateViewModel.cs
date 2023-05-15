namespace ISpan.Project_02_DessertStory.Customer.ViewModels.Sellers
{
    public class SellerCreateViewModel
    {
        public int Id { get; set; }
        public string Account { get; set; } = null!;
        public string Password { get; set; } = null!;
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

        public IFormFile photo { get; set; }
    }
}
