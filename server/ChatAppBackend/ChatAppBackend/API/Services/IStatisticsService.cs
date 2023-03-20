using ChatAppBackend.API.Models;

namespace ChatAppBackend.API.Services;

public interface IStatisticsService
{
    Task<StatisticsResponseV1> GetStatistics();
    Task<StatisticsResponseV1> GetStatisticsByUser(string user);
    Task<StatisticsResponseV1> GetStatisticsByChannelId(uint channelId);
}
