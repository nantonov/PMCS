using Microsoft.AspNetCore.Http;
using Schedule.Application.Core.Abstractions.Services;
using Schedule.Application.Core.Exceptions;
using Schedule.Application.Core.Utility;
using System.Security.Claims;

namespace Schedule.Application.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly IHttpContextAccessor _context;
        private readonly IAuthService _authService;

        public IdentityService(IHttpContextAccessor context, IAuthService authService)
        {
            _context = context;
            _authService = authService;
        }

        public int GetUserId()
        {
            var idFromClaims = _context.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            Int32.TryParse(idFromClaims, out var id);

            return id;
        }

        public async Task<string?> GetUserEmail()
        {
            var claims = await _authService.GetUserClaims();

            var emailFromClaims = claims.FirstOrDefault(x => x.Type == "email")?.Value;

            var (result, email) = Ensure.IsValidEmail(emailFromClaims);

            if (!result) throw new InvalidNameIdentifierClaimException(email);

            return email;
        }

        public bool IsAuthenticated()
        {
            var isAuthenticated = _context.HttpContext.User.Identity!.IsAuthenticated;

            return isAuthenticated;
        }
    }
}
