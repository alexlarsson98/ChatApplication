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

    [HttpGet(BaseUrlV1)]
    public async Task<ActionResult<StatisticsV1>> GetStatistics()
    {
        return Ok(await _service.GetStatistics());
    }

    [HttpGet(BaseUrlV1 + "/by-user/{user}")]
    public async Task<ActionResult<StatisticsV1>> GetStatisticsByUser(
        [Required, FromRoute] string user)
    {
        return Ok(await _service.GetStatisticsByUser(user));
    }

    [HttpGet(BaseUrlV1 + "/by-channel-id/{channelId}")]
    public async Task<ActionResult<StatisticsV1>> GetStatisticsByChannelId(
        [Required, FromRoute] uint channelId)
    {
        return Ok(await _service.GetStatisticsByChannelId(channelId));
    }
}
