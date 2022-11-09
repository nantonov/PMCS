using System.Net.Mail;

namespace Schedule.Application.Core.Utility
{
    public static class Ensure
    {
        public static (bool succeed, string? address) IsValidEmail(string? email)
        {
            if (email is null) return (false, null);

            var succeed = MailAddress.TryCreate(email, out var validEmail);

            return (succeed, validEmail?.Address);
        }
    }
}
