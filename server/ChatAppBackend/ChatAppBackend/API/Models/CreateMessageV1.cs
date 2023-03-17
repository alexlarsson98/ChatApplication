namespace ChatAppBackend.API.Models;

public record CreateMessageV1
{
    public string User { get; set; }
    public string Message { get; set; }
    public uint ChannelId { get; set; }
}
