using System;
using CloudinaryDotNet.Actions;
using Grandeur_BE_DotNet.Controllers;
using Grandeur_BE_DotNet.Models.Entitiles;
using Grandeur_BE_DotNet.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Grandeur_BE_DotNet.Grandeur_BE_Dotnet_Tests.Controllers;

public class UsersControllerTests
{
    private readonly Mock<IUserRepository> _userRepoMock = new();
    private readonly UsersController _controller;

    public UsersControllerTests()
    {
        _controller = new UsersController(_userRepoMock.Object);
    }

    [Fact]
    public async Task GetUsersAsync_ReturnsOkWithUsers()
    {
        var users = new List<User>
        {
            new() { Id = 1, Email = "test1@gmail.com", Password = "Password@123" },
            new() { Id = 2, Email = "test2@gmail.com", Password = "Password@123" },
        };

        _userRepoMock.Setup(repo => repo.GetUsersAsync()).ReturnsAsync(users);

        // Calling the api
        var result = await _controller.GetUsersAsync();

        // Assertions
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnValue = Assert.IsType<List<User>>(okResult.Value);
        Assert.Equal(2, returnValue.Count);

    }
}
