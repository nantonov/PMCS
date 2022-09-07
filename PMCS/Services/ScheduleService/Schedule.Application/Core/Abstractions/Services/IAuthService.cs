namespace Schedule.Application.Core.Abstractions.Services
{
    public interface IAuthService
    {
        Task<string> GetAccessToken(string scope);
    }
}
