using ChatAppBackend.API.Models;

namespace ChatAppBackend.API.Services;

public interface IMessageService
{
    Task<MessageV1> CreateMessage(CreateMessageV1 request);
    Task<List<MessageV1>> GetMessagesByChannelId(uint channelId);
}
