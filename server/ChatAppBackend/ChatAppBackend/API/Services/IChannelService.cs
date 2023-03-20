using ChatAppBackend.API.Models;

namespace ChatAppBackend.API.Services;

public interface IChannelService
{
    Task<List<ChannelV1>> GetChannels();
}
