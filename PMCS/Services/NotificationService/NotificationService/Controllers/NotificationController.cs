using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Notifications.API.Models.Requests;
using Notifications.BLL.Interfaces.Services;
using Notifications.BLL.Models.DTOs;

namespace Notifications.API.Controllers
{
    [Route("api/notify/")]
    [ApiController]
    [Authorize]
    public class NotificationController : ControllerBase
    {
        private readonly IEmailService _emailService;
        private readonly IClientService _clientService;
        private readonly IMapper _mapper;
        private readonly IValidator<SendClientNotificationViewModel> _sendClientNotificationValidator;
        private readonly IValidator<SendEmailNotificationViewModel> _sendEmailNotificationValidator;


        public NotificationController(IMapper mapper,
            IEmailService emailService,
            IClientService clientService,
            IValidator<SendClientNotificationViewModel> sendClientNotificationValidator,
            IValidator<SendEmailNotificationViewModel> sendEmailNotificationValidator)

        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _emailService = emailService ?? throw new ArgumentNullException(nameof(emailService));
            _clientService = clientService ?? throw new ArgumentNullException(nameof(clientService));
            _sendClientNotificationValidator = sendClientNotificationValidator ?? throw new ArgumentNullException(nameof(sendClientNotificationValidator));
            _sendEmailNotificationValidator = sendEmailNotificationValidator ?? throw new ArgumentNullException(nameof(sendEmailNotificationValidator));
        }

        [HttpPost("email")]
        public async Task<IActionResult> NotifyByEmail([FromBody] SendEmailNotificationViewModel viewModel, CancellationToken cancellationToken)
        {
            await _sendEmailNotificationValidator.ValidateAndThrowAsync(viewModel, cancellationToken);

            var notification = _mapper.Map<EmailNotification>(viewModel);

            await _emailService.SendNotification(notification);

            return Ok(notification);
        }

        [HttpPost("client")]
        public async Task<IActionResult> NotifyClient([FromBody] SendClientNotificationViewModel viewModel, CancellationToken cancellationToken)
        {
            await _sendClientNotificationValidator.ValidateAndThrowAsync(viewModel, cancellationToken);

            var notification = _mapper.Map<ClientNotification>(viewModel);

            await _clientService.SendNotification(notification);

            return Ok(notification);
        }
    }
}
