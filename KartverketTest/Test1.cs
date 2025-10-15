using KartverketProject.Controllers;
using KartverketProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Assert = Xunit.Assert;

public class ControllerTest
{
    // Test if the ModelState is valid
    [Fact]
    public void ModelStateValidation()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase("TestDb")
            .Options;

        var context = new ApplicationDbContext(options);
        var controller = new ObstacleController(context);
        var obstacleData = new ObstacleData();

        // Act
        var result = controller.DataForm() as ViewResult;

        // Assert
        Assert.NotNull(result);
        Assert.True(controller.ModelState.IsValid);
    }

    // Test if the DataForm saves the obstacle data to the database
    [Fact]
    public async Task DataFormSaveToDatabase()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase("TestDb")
            .Options;

        var context = new ApplicationDbContext(options);
        var controller = new ObstacleController(context);
        var date = new DateTime(2025, 10, 15, 14, 30, 0);

        var obstacleData = (new ObstacleData
        {
            obstacleId = 0,
            obstacleName = "tower",
            obstacleHeight = 5.5,
            obstacleDescription = "test",
            obstacleSubmittedDate = date,
            obstacleJson = "1"
        });

        // Act
        var obstacle = await controller.DataForm(obstacleData);

        // Assert
        var savedObstacle = context.Obstacles.FirstOrDefault(o => o.obstacleName == "tower");
        Assert.NotNull(obstacle);
        Assert.Equal("tower", savedObstacle.obstacleName);
    }

    // Test if the user can authenticate
    [Fact]
    public async Task UserSaveToDatabase()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        var context = new ApplicationDbContext(options);

        context.Users.Add(new User { Username = "john", Password = "smith" });
        await context.SaveChangesAsync();

        var controller = new AuthenticationController(context);

        var existingUser = new User
        {
            Username = "john",
            Password = "smith"
        };

        // Act
        var login = await controller.Login(existingUser);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(login);
        Assert.Equal("Login successful.", okResult.Value);
    }
}
