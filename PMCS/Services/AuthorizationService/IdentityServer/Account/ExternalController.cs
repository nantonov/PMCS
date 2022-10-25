using IdentityModel;
using IdentityServer.Models;
using IdentityServer4;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace IdentityServerHost.Quickstart.UI
{
    [SecurityHeaders]
    [AllowAnonymous]
    public class ExternalController : Controller
    {
        private readonly UserManager<User> _users;
        private readonly IIdentityServerInteractionService _interaction;
        public ExternalController(
            IIdentityServerInteractionService interaction,
            UserManager<User> users)
        {
            _users = users;

            _interaction = interaction;
        }

        [HttpGet]
        public IActionResult Challenge(string scheme, string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl)) returnUrl = "~/";

            if (Url.IsLocalUrl(returnUrl) == false && _interaction.IsValidReturnUrl(returnUrl) == false)
            {
                throw new Exception("invalid return URL");
            }

            var props = new AuthenticationProperties
            {
                RedirectUri = Url.Action(nameof(Callback)),
                Items =
                {
                    { "returnUrl", returnUrl },
                    { "scheme", scheme },
                }
            };

            return Challenge(props, scheme);

        }

        [HttpGet]
        public async Task<IActionResult> Callback()
        {
            var result = await HttpContext.AuthenticateAsync(IdentityServerConstants.ExternalCookieAuthenticationScheme);

            if (result?.Succeeded != true)
            {
                throw new Exception("External authentication error");
            }

            var (user, provider, claims) = FindUserFromExternalProvider(result);

            if (user == null)
            {
                user = await AutoProvisionUser(claims);
            }

            await HttpContext.SignInAsync(new IdentityServerUser(user.Id.ToString())
            {
                DisplayName = user.UserName,
                IdentityProvider = provider
            });

            await HttpContext.SignOutAsync(IdentityServerConstants.ExternalCookieAuthenticationScheme);

            var returnUrl = result.Properties.Items["returnUrl"] ?? "~/";

            return Redirect(returnUrl);
        }

        private (User user, string provider, IEnumerable<Claim> claims) FindUserFromExternalProvider(AuthenticateResult result)
        {
            var externalUser = result.Principal;

            var userIdClaim = externalUser.FindFirst(JwtClaimTypes.Subject) ??
                              externalUser.FindFirst(ClaimTypes.NameIdentifier) ??
                              throw new Exception("Unknown userid");

            var claims = externalUser.Claims.ToList();
            claims.Remove(userIdClaim);
            var email = claims.FirstOrDefault(x => x.Type == "email").Value;

            var provider = result.Properties.Items["scheme"];
            var providerUserId = userIdClaim.Value;

            var user = _users.FindByEmailAsync(email).GetAwaiter().GetResult();

            return (user, provider, claims);
        }

        private async Task<User> AutoProvisionUser(IEnumerable<Claim> claims)
        {
            var email = claims.FirstOrDefault(x => x.Type == "email").Value;
            var username = email.Split("@")[0];

            await _users.CreateAsync(new User
            {
                Email = email,
                UserName = username

            });

            var user = await _users.FindByEmailAsync(email);

            await _users.AddClaimsAsync(user, claims);

            return user;
        }
    }
}