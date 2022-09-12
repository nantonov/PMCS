﻿using System.Net.Mail;

namespace Schedule.Application.Core.Utility
{
    public static class Ensure
    {
        public static (bool, string) IsValidEmail(string email)
        {
            var succeed = MailAddress.TryCreate(email, out var validEmail);

            return (succeed, validEmail.Address);
        }
    }
}