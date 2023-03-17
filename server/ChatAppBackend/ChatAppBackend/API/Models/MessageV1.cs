namespace ChatAppBackend.API.Models;

public record MessageV1
{
    public uint? Id { get; set; }
    public string User { get; set; }
    public string Message { get; set; }
    public DateTime CreatedAt { get; set; }
}
