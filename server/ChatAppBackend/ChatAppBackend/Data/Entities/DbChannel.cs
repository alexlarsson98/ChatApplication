using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChatAppBackend.Data.Entities;

[Table("Channels"), Index("ChannelName", IsUnique = true)]
public class DbChannel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public uint? Id { get; set; }

    public string ChannelName { get; set; }

    public ICollection<DbMessage> LibraryItems { get; set; }
        = new List<DbMessage>();
}
