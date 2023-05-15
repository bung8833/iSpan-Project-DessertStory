
using System.Diagnostics.SymbolStore;

namespace ISpan.Project_02_DessertStory.Customer.Models.Services.Interfaces
{
    public interface IEmailService
    {
        Task SendAuthenticationEmailAsync(string recipientEmail, string authenticationUrl,string username);
    }
}
