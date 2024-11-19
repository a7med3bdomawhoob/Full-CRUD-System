﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NamaaWebSite.Dto;
using NamaaWebSite.Helpers;

namespace NamaaWebSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly EmailService _emailService;

        public EmailController(EmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendEmail(EmailRequest emailRequest)
        {
            await _emailService.SendEmailAsync(emailRequest.First, emailRequest.Last,emailRequest.ToEmail, emailRequest.Subject, emailRequest.Body);
            return Ok();
        }
    }
}