using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Encodings.Web;

namespace Notifications.API.Authentication
{
    public class CustomAuthenticationOptions : AuthenticationSchemeOptions { }

    public class CustomAuthenticationHandler : AuthenticationHandler<CustomAuthenticationOptions>
    {
        public CustomAuthenticationHandler(
            IOptionsMonitor<CustomAuthenticationOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock) : base(options, logger, encoder, clock) { }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
                return await Task.Run(() => AuthenticateResult.Fail("Unauthorized"));

            string authorizationHeader = Request.Headers["Authorization"];

            if (string.IsNullOrEmpty(authorizationHeader))
            {
                return await Task.Run(AuthenticateResult.NoResult);
            }

            if (!authorizationHeader.StartsWith("Bearer", StringComparison.OrdinalIgnoreCase))
            {
                return await Task.Run(() => AuthenticateResult.Fail("Unauthorized"));
            }

            string token = authorizationHeader.Substring("Bearer".Length).Trim();

            if (string.IsNullOrEmpty(token))
            {
                return await Task.Run(() => AuthenticateResult.Fail("Unauthorized"));
            }

            try
            {
                return Authenticate(token);
            }
            catch (Exception)
            {
                return await Task.Run(() => AuthenticateResult.Fail("Unauthorized"));
            }
        }

        private AuthenticateResult Authenticate(string token)
        {
            var validatedToken = ValidateToken(token);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, GetJwtTokenClaim(validatedToken, ClaimTypes.NameIdentifier) ?? string.Empty),
                new Claim(ClaimTypes.Email, GetJwtTokenClaim(validatedToken, ClaimTypes.Email) ?? string.Empty),
            };

            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new System.Security.Principal.GenericPrincipal(identity, null);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);
            return AuthenticateResult.Success(ticket);
        }

        private static string? GetJwtTokenClaim(JwtSecurityToken securityToken, string claimName)
        {
            var claimValue = securityToken.Claims.FirstOrDefault(c => c.Type == claimName)?.Value;

            return claimValue;
        }

        private static JwtSecurityToken ValidateToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);

            var securityToken = (JwtSecurityToken)tokenHandler.ReadToken(token);

            return securityToken;
        }
    }
}
