using ChatAppBackend.API.Models;
using ChatAppBackend.API.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ChatAppBackend.API.Controllers;

public class StatisticsController : ControllerBase
{
    public const string BaseUrlV1 = "/v1/statistics";

    private readonly IStatisticsService _service;

    public StatisticsController(IStatisticsService service)
    {
        _service = service;
    }

    [HttpGet(BaseUrlV1 + "/get-number-of-messages")]
    public async Task<ActionResult<StatisticV1>> GetNumberOfMessages()
    {
        return Ok(await _service.GetNumberOfMessages());
    }

    [HttpGet(BaseUrlV1 + "/get-number-of-messages-by-user/{user}")]
    public async Task<ActionResult<StatisticV1>> GetNumberOfMessagesByUser(
        [Required, FromRoute] string user)
    {
        return Ok(await _service.GetNumberOfMessagesByUser(user));
    }

    [HttpGet(BaseUrlV1 + "/get-number-of-messages-by-channel-id/{channelId}")]
    public async Task<ActionResult<StatisticV1>> GetNumberOfMessagesByChannelId(
        [Required, FromRoute] uint channelId)
    {
        return Ok(await _service.GetNumberOfMessagesByChannelId(channelId));
    }
}
