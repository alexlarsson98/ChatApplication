using AutoMapper;
using ChatAppBackend.API.Models;
using ChatAppBackend.Data;
using Microsoft.EntityFrameworkCore;

namespace ChatAppBackend.API.Services;

public class ChannelService : IChannelService
{
    private readonly ChatAppDbContext _dbContext;
    private readonly IMapper _mapper;

    public ChannelService(ChatAppDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<List<ChannelV1>?> GetChannels()
    {
        var entities = await _dbContext.Channels
                        .ToListAsync();

        return _mapper.Map<List<ChannelV1>>(entities);
    }
}
