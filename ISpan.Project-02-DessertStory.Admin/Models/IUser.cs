namespace ISpan.Project_02_DessertStory.Admin.Models
{
    public interface IUser
    {
        public int Id { get; set; }
        public string Account { get; set; } 
        public string Password { get; set; } 
        public string IdentityNumber { get; set; } 
        public string FirstName { get; set; } 
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool SuspensionStatus { get; set; }
    }
}
