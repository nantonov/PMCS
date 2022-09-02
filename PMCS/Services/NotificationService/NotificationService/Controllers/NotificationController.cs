using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Notifications.API.Models.Requests;
using Notifications.BLL.Interfaces.Services;
using Notifications.BLL.Models.DTOs;

namespace Notifications.API.Controllers
{
    [Route("api/notify/")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Custom")]
    public class NotificationController : ControllerBase
    {
        private readonly IEmailService _emailService;
        private readonly IClientService _clientService;
        private readonly IMapper _mapper;

        public NotificationController(IMapper mapper, IEmailService emailService, IClientService clientService)
        {
            _mapper = mapper ?? throw new NullReferenceException();
            _emailService = emailService ?? throw new NullReferenceException();
            _clientService = clientService ?? throw new NullReferenceException();
        }

        [HttpPost("/email")]
        public async Task<IActionResult> NotifyByEmail([FromBody] EmailNotificationRequest request)
        {
            var notification = _mapper.Map<EmailNotification>(request);

            await _emailService.SendNotification(notification);

            return Ok(notification);
        }

        [HttpPost("/client")]
        public async Task<IActionResult> NotifyClient([FromBody] ClientNotificationRequest request, CancellationToken cancellationToken)
        {
            var notification = _mapper.Map<ClientNotification>(request);

            await _clientService.SendNotification(notification);

            return Ok(notification);
        }
    }
}
