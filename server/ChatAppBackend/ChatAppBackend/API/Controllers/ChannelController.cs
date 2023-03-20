using ChatAppBackend.API.Models;
using ChatAppBackend.API.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ChatAppBackend.API.Controllers;

public class ChannelController : ControllerBase
{
    public const string BaseUrlV1 = "/v1/channels";

    private readonly IChannelService _service;

    public ChannelController(IChannelService service)
    {
        _service = service;
    }

    [HttpGet(BaseUrlV1)]
    [SwaggerOperation(
        Summary = "Get channels",
        Description = "Fetches all channels"
    )]
    public async Task<ActionResult<List<ChannelV1>>> GetChannels()
    {
        return Ok(await _service.GetChannels());
    }
}
