using KartverketProject.Controllers;
using KartverketProject.Data;
using KartverketProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Assert = Xunit.Assert;

public class ControllerTest
{
    // Test if the ModelState is valid when accessing the DataForm view
    [Fact]
    public void ModelStateValidation()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase("TestDb")
            .Options;

        var context = new ApplicationDbContext(options);
        var service = new ObstacleService(context);
        var controller = new ObstacleController(service);

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
            .UseInMemoryDatabase("TestDb_Save")
            .Options;

        var context = new ApplicationDbContext(options);
        var service = new ObstacleService(context);
        var controller = new ObstacleController(service);
        var date = new DateTime(2025, 10, 15, 14, 30, 0);

        var obstacleData = new ObstacleData
        {
            ObstacleId = 0,
            ObstacleName = "john",
            ObstacleHeight = 5.5,
            ObstacleDescription = "test",
            ObstacleSubmittedDate = date,
            ObstacleJSON = "1"
        };

        // Act
        var obstacle = await controller.DataForm(obstacleData);

        // Assert
        var savedObstacle = context.Obstacles.FirstOrDefault(o => o.ObstacleName == "john");
        Assert.NotNull(obstacle);
        Assert.NotNull(savedObstacle);
        Assert.Equal("john", savedObstacle.ObstacleName);
    }
}
