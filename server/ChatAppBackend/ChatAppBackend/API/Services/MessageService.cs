using AutoMapper;
using ChatAppBackend.API.Exceptions;
using ChatAppBackend.API.Models;
using ChatAppBackend.Data;
using ChatAppBackend.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChatAppBackend.API.Services;

public class MessageService : IMessageService
{
    private readonly ChatAppDbContext _dbContext;
    private readonly IMapper _mapper;

    public MessageService(ChatAppDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<MessageV1> CreateMessage(CreateMessageV1 request)
    {
        var channel = await _dbContext.Channels
                        .Where(c => c.Id.Equals(request.ChannelId))
                        .FirstOrDefaultAsync();

        if (channel == null)
        {
            throw new ResourceNotFoundException("Channel not found");
        }

        var entity = new DbMessage
        {
            User = request.User,
            Message = request.Message,
            Channel = channel
        };

        _dbContext.Messages.Add(entity);

        await _dbContext.SaveChangesAsync();

        return _mapper.Map<MessageV1>(entity);
    }
}
