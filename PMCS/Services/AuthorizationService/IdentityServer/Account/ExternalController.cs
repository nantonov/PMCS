using IdentityServer4;
using IdentityServer4.Services;
using IdentityServer4.Stores;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace IdentityServerHost.Quickstart.UI
{
    [SecurityHeaders]
    [AllowAnonymous]
    public class ExternalController : Controller
    {
        private readonly IIdentityServerInteractionService _interaction;
        private readonly IClientStore _clientStore;
        private readonly ILogger<ExternalController> _logger;
        private readonly IEventService _events;
        public ExternalController(
            IIdentityServerInteractionService interaction,
            IClientStore clientStore,
            IEventService events,
            ILogger<ExternalController> logger)
        {
            _interaction = interaction;
            _clientStore = clientStore;
            _logger = logger;
            _events = events;
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

            var externalUser = result.Principal;

            if (externalUser == null)
            {
                throw new Exception("External authentication error");
            }

            var claims = externalUser.Claims.ToList();

            var userIdClaim = claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

            if (userIdClaim == null)
            {
                throw new Exception("Unknown userid");
            }

            var email = claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;
            var username = email.Split("@")[0];
            var externalProvider = userIdClaim.Issuer;

            await HttpContext.SignInAsync(new IdentityServerUser(userIdClaim.Value)
            {
                DisplayName = username,
                IdentityProvider = externalProvider,
                AdditionalClaims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Email, email),
                },
                AuthenticationTime = DateTime.UtcNow
            });

            await HttpContext.SignOutAsync(IdentityServerConstants.ExternalCookieAuthenticationScheme);


            var returnUrl = result.Properties.Items["returnUrl"] ?? "~/";

            return Redirect(returnUrl);
        }
    }
}