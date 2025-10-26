
namespace SumitPortfolio.Web.Interfaces
{
    public interface IEmailService
    {
        bool SendEmailWithoutBcc(string to_email, string subject, string body);
    }
}
