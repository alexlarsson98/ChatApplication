using ChatAppBackend.API.Models;

namespace ChatAppBackend.API.Services;

public interface IStatisticsService
{
    Task<StatisticsV1> GetStatistics();
    Task<StatisticsV1> GetStatisticsByUser(string user);
    Task<StatisticsV1> GetStatisticsByChannelId(uint channelId);
}
