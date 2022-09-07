using Microsoft.AspNetCore.Http;
using Schedule.Application.Core.Abstractions.Services;
using Schedule.Application.Core.Exceptions;
using Schedule.Application.Core.Utility;
using System.Security.Claims;

namespace Schedule.Infrastructure.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly IHttpContextAccessor _context;

        public IdentityService(IHttpContextAccessor context)
        {
            _context = context;
        }

        public int GetUserId()
        {
            var idFromClaims = _context.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            Int32.TryParse(idFromClaims, out var id);

            return id;
        }

        public string GetUserEmail()
        {
            var emailFromClaims = _context.HttpContext?.User?.FindFirst(ClaimTypes.Email)?.Value;

            var (result, email) = Ensure.IsValidEmail(emailFromClaims);

            if (!result) throw new InvalidNameIdentifierClaimException(email);

            return email;
        }

        public bool IsAuthenticated()
        {
            var isAuthenticated = _context.HttpContext.User.Identity.IsAuthenticated;

            return isAuthenticated;
        }
    }
}
