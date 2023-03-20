namespace ChatAppBackend.API.Models;

public record ChannelV1
{
    public uint? Id { get; set; }
    public string ChannelName { get; set; }
}
