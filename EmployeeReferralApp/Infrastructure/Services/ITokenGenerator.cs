namespace EmployeeReferralApp.Infrastructure.Services
{
    public interface ITokenGenerator
    {
        string GenerateFor(string username);
    }
}