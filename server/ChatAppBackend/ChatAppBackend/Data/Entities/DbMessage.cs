using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ChatAppBackend.Data.Entities;

[Table("Messages")]
public class DbMessage
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public uint? Id { get; set; }

    public string User { get; set; }
    public string Message { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [ForeignKey("Channel")]
    public uint ChannelId { get; set; }
    public DbChannel Channel { get; set; }
}
