using ChatAppBackend.API.Models;
using ChatAppBackend.API.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
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
    [SwaggerOperation(
        Summary = "Creates a new Message",
        Description = "Creates a message based on the request body"
    )]
    public async Task<ActionResult<MessageV1>> CreateMessage(
        [Required, FromBody] CreateMessageV1 request)
    {
        return Ok(await _service.CreateMessage(request));
    }

    [HttpGet(BaseUrlV1 + "/get-messages-by-channel-id/{channelId}")]
    [SwaggerOperation(
        Summary = "Get messages by channel id",
        Description = "Fetches messages for a specified channel id"
    )]
    public async Task<ActionResult<MessageV1>> GetMessagesByChannelId(
        [Required, FromRoute] uint channelId)
    {
        return Ok(await _service.GetMessagesByChannelId(channelId));
    }
}
