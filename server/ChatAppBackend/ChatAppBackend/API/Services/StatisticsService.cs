using ChatAppBackend.API.Models;
using ChatAppBackend.Data;
using Microsoft.EntityFrameworkCore;

namespace ChatAppBackend.API.Services;

public class StatisticsService : IStatisticsService
{
    private readonly ChatAppDbContext _dbContext;

    public StatisticsService(ChatAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<StatisticV1> GetNumberOfMessages()
    {
        var entities = await _dbContext.Messages
                        .ToListAsync();

        return new StatisticV1 { NumberOfMessages = entities.Count() };
    }

    public async Task<StatisticV1> GetNumberOfMessagesByUser(string user)
    {
        var entities = await _dbContext.Messages
            .Where(m => m.User == user)
            .ToListAsync();

        return new StatisticV1 { NumberOfMessages = entities.Count() };
    }

    public async Task<StatisticV1> GetNumberOfMessagesByChannelId(uint channelId)
    {
        var entities = await _dbContext.Messages
            .Where(m => m.ChannelId == channelId)
            .ToListAsync();

        return new StatisticV1 { NumberOfMessages = entities.Count() };
    }
}
