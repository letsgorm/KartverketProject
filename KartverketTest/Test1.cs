using KartverketProject.Controllers;
using KartverketProject.Dtos;
using KartverketProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Security.Claims;
using Xunit;
using Assert = Xunit.Assert;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

public class ControllerTest
{
    [Fact]
    public void ModelStateValidation()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase("TestDb_ModelState")
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

        // Mock a logged-in user
        var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.NameIdentifier, "test-user-id")
        }, "mock"));
        controller.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext { User = user }
        };

        var obstacleData = new Obstacle
        {
            ObstacleName = "john",
            ObstacleHeight = 5.5,
            ObstacleDescription = "test",
            ObstacleSubmittedDate = new DateTime(2025, 10, 15, 14, 30, 0),
            ObstacleJSON = "1"
        };

        // Act
        var result = await controller.DataForm(obstacleData);

        // Assert
        var savedObstacle = await context.Obstacle.FirstOrDefaultAsync(o => o.ObstacleName == "john");
        Assert.NotNull(result);
        Assert.NotNull(savedObstacle);
        Assert.Equal("john", savedObstacle.ObstacleName);
    }

    [Fact]
    public async Task UserLoginTest_WithMoq()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase("TestDb_User")
            .Options;
        var context = new ApplicationDbContext(options);

        var userStore = new Mock<IUserStore<User>>();
        var mockUserManager = new Mock<UserManager<User>>(userStore.Object, null, null, null, null, null, null, null, null);
        var mockSignInManager = new Mock<SignInManager<User>>(
            mockUserManager.Object,
            new Mock<Microsoft.AspNetCore.Http.IHttpContextAccessor>().Object,
            new Mock<IUserClaimsPrincipalFactory<User>>().Object,
            null, null, null, null
        );

        var testUser = new User
        {
            Id = "1",
            UserName = "alpha",
            Email = "alpha@example.com"
        };

        mockUserManager.Setup(x => x.FindByNameAsync("alpha")).ReturnsAsync(testUser);
        mockSignInManager.Setup(x => x.PasswordSignInAsync("alpha", "alpha123", false, true))
            .ReturnsAsync(SignInResult.Success);

        var authService = new UserService(mockUserManager.Object, mockSignInManager.Object, context);
        var controller = new AccountController(mockUserManager.Object, mockSignInManager.Object, context, null);

        var loginModel = new LoginRequest
        {
            UserName = "alpha",
            Password = "alpha123"
        };

        // Act
        var result = await controller.Login(loginModel);

        // Assert
        var redirectResult = Assert.IsType<RedirectToActionResult>(result);
        Assert.Equal("DataForm", redirectResult.ActionName);
        Assert.Equal("Obstacle", redirectResult.ControllerName);
    }
}
