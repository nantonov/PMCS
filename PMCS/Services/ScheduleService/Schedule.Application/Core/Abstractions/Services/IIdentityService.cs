namespace Schedule.Application.Core.Abstractions.Services
{
    public interface IIdentityService
    {
        public int GetUserId();
        public Task<string?> GetUserEmail();
        public bool IsAuthenticated();
    }
}
