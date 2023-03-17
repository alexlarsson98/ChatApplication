using ChatAppBackend.API.Models;
using ChatAppBackend.API.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ChatAppBackend.API.Controllers;

public class MessageController : ControllerBase
{
    public const string BaseUrlV1 = "/v1/messages";

    private readonly IMessageService _service;

    public MessageController(IMessageService service)
    {
        _service = service;
    }

    [HttpPost(BaseUrlV1)]
    public async Task<ActionResult<MessageV1>> CreateMessage(
        [Required, FromBody] CreateMessageV1 request)
    {
        return Ok(await _service.CreateMessage(request));
    }
}
