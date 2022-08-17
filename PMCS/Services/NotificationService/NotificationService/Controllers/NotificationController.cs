using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Notifications.API.Models.Requests;
using Notifications.BLL.Interfaces.Services;
using Notifications.BLL.Models.Payloads;

namespace Notifications.API.Controllers
{
    [Route("api/notify/")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly IEmailService _emailService;
        private readonly IMapper _mapper;
        public NotificationController(IMapper mapper, IEmailService emailService)
        {
            _mapper = mapper ?? throw new NullReferenceException();
            _emailService = emailService ?? throw new NullReferenceException();
        }

        [HttpPost("/email")]
        public async Task<IActionResult> NotifyByEmail([FromBody] EmailNotificationRequest request)
        {
            var payload = _mapper.Map<EmailNotificationPayload>(request);

            await _emailService.SendNotification(payload);

            return Ok(payload);
        }
    }
}
