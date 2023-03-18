using ChatAppBackend.API.Models;
using ChatAppBackend.Data.Entities;

namespace ChatAppBackend.Tests.MockData;

public class MessageData
{
    public static CreateMessageV1 GetCreateMessageRequest()
    {
        return new CreateMessageV1
        {
            User = "test-user",
            Message = "test-message",
            ChannelId = 1
        };
    }

    public static List<DbChannel> GetChannels()
    {
        return new List<DbChannel>{
             new DbChannel{
                 ChannelName = "Channel 1"
             },
             new DbChannel{
                 ChannelName = "Channel 2"
             }
         };
    }
}
