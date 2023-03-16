using ChatAppBackend.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChatAppBackend.Data;

public class ChatAppDbContext : DbContext
{
    public ChatAppDbContext(DbContextOptions<ChatAppDbContext> options)
            : base(options)
    { }

    public DbSet<DbChannel> Channels { get; set; }
    public DbSet<DbMessage> Messages { get; set; }
}
