namespace Schedule.Application.Core.Abstractions.Services
{
    public interface IIdentityService
    {
        public int GetUserId();
        public string GetUserEmail();
        public bool IsAuthenticated();
    }
}
