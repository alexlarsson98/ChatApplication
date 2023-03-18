using AutoMapper;
using ChatAppBackend.API.Exceptions;
using ChatAppBackend.API.Helpers;
using ChatAppBackend.API.Models;
using ChatAppBackend.API.Services;
using ChatAppBackend.Data;
using ChatAppBackend.Tests.MockData;
using Microsoft.EntityFrameworkCore;

namespace ChatAppBackend.Tests.Services;

public class MessageServiceTests
{
    protected readonly ChatAppDbContext _dbContext;
    private readonly IMapper _mapper;

    public MessageServiceTests()
    {
        var options = new DbContextOptionsBuilder<ChatAppDbContext>()
        .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
        .Options;

        _dbContext = new ChatAppDbContext(options);

        _dbContext.Database.EnsureCreated();

        var mappingConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new MappingProfile());
        });
        IMapper mapper = mappingConfig.CreateMapper();

        _mapper = mapper;
    }

    [Fact]
    // Should successfully create a message for a channel that exists in database
    public async Task CreateMessage_WithExistingChannel()
    {
        // Arrange
        _dbContext.Channels.AddRange(MessageData.GetChannels());
        _dbContext.SaveChanges();

        var request = MessageData.GetCreateMessageRequest();

        IMessageService service = new MessageService(_dbContext, _mapper);

        // Act
        var result = await service.CreateMessage(request);

        //Assert
        Assert.IsType<MessageV1>(result);
    }

    [Fact]
    // Referenced channel not existing in database should result in exception being thrown
    public async Task CreateMessage_WithChannelNotFound()
    {
        // Arrange
        var request = MessageData.GetCreateMessageRequest();

        IMessageService service = new MessageService(_dbContext, _mapper);

        // Act and Assert
        try
        {
            var result = await service.CreateMessage(request);
            Assert.Fail("No exception thrown for channel not found");
        }
        catch (Exception ex)
        {
            Assert.True(ex is ResourceNotFoundException);
        }
    }
}
