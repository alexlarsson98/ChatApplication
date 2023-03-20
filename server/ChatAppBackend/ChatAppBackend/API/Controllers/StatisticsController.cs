using ChatAppBackend.API.Models;
using ChatAppBackend.API.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
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

    [HttpGet(BaseUrlV1)]
    [SwaggerOperation(
        Summary = "Fetch statistics",
        Description = "Fetches all statistics"
    )]
    public async Task<ActionResult<StatisticsResponseV1>> GetStatistics()
    {
        return Ok(await _service.GetStatistics());
    }

    [HttpGet(BaseUrlV1 + "/by-user/{user}")]
    [SwaggerOperation(
        Summary = "Fetch statistics by user",
        Description = "Fetches statistics belonging to a specified user"
    )]
    public async Task<ActionResult<StatisticsResponseV1>> GetStatisticsByUser(
        [Required, FromRoute] string user)
    {
        return Ok(await _service.GetStatisticsByUser(user));
    }

    [HttpGet(BaseUrlV1 + "/by-channel-id/{channelId}")]
    [SwaggerOperation(
        Summary = "Fetch statistics by channel id",
        Description = "Fetches statistics belonging to a specified channel"
    )]
    public async Task<ActionResult<StatisticsResponseV1>> GetStatisticsByChannelId(
        [Required, FromRoute] uint channelId)
    {
        return Ok(await _service.GetStatisticsByChannelId(channelId));
    }
}
