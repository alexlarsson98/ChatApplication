using ChatAppBackend.Data.Entities;

namespace ChatAppBackend.Data.Seeds;

public class DatabaseInitializer
{
    public static void Initialize(ChatAppDbContext dbContext)
    {
        ArgumentNullException.ThrowIfNull(dbContext, nameof(dbContext));
        dbContext.Database.EnsureCreated();

        if (!dbContext.Channels.Any())
        {
            var channels = new List<DbChannel>()
                {
                        new DbChannel()
                        {
                            ChannelName = "Channel 1"
                        },
                        new DbChannel()
                        {
                            ChannelName = "Channel 2"
                        },
                        new DbChannel()
                        {
                            ChannelName = "Channel 3"
                        },
                        new DbChannel()
                        {
                            ChannelName = "Channel 4"
                        }
                };

            dbContext.Channels.AddRange(channels);
            dbContext.SaveChanges();
        }
    }
}
