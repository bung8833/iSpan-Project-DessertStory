namespace ISpan.Project_02_DessertStory.Customer.Models.Services.Interfaces
{
    public interface IPasswordHasher
    {

        string Hash(string password);

        bool Verify(string passwordHash, string inputPassword);
    }
}
