using ChatAppBackend.API.Models;

namespace ChatAppBackend.API.Services;

public interface IStatisticsService
{
    Task<StatisticV1> GetNumberOfMessages();
    Task<StatisticV1> GetNumberOfMessagesByUser(string user);
    Task<StatisticV1> GetNumberOfMessagesByChannelId(uint channelId);
}
