namespace ISpan.Project_02_DessertStory.Admin.Models
{
    public interface IPasswordHasher
    {
        string Hash(string password);

        bool Verify(string passwordHash, string inputPassword);
    }
}