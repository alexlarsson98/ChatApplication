using ChatAppBackend.API.Controllers;
using ChatAppBackend.API.Models;
using ChatAppBackend.API.Services;
using ChatAppBackend.Tests.MockData;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace ChatAppBackend.Tests.Controllers;

public class MessageControllerTests
{
    private readonly Mock<IMessageService> _mockService;
    private readonly MessageController _controller;

    public MessageControllerTests()
    {
        _mockService = new Mock<IMessageService>();
        _controller = new MessageController(_mockService.Object);
    }

    [Fact]
    // Created message should return ActionResult 200 Ok
    public async Task CreateMessage_ReturnsOk()
    {
        // Arrange
        var request = MessageData.GetCreateMessageRequest();

        // Act
        var result = await _controller.CreateMessage(request);

        //Assert
        Assert.IsType<ActionResult<MessageV1>>(result);
        Assert.IsAssignableFrom<OkObjectResult>(result.Result);
    }
}