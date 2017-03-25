using Moq;
using NUnit.Framework;
using SociumApp.Areas.Profile.Controllers;
using SociumApp.Areas.Profile.Models;
using SociumApp.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using TestStack.FluentMVCTesting;

namespace SociumApp.Tests.WebClient.Tests.Controllers.Tests.User.Tests
{
    [TestFixture]
    public class UserControllerTests
    {
        [Test]
        public void UserController_Constructor_Should_Initialize_Object()
        {
            //Arrange & Act
            var mockedService = new Mock<IUserService>();
            UserController controller = new UserController(mockedService.Object);

            //Assert
            Assert.IsInstanceOf<UserController>(controller);
        }

        [Test]
        public void UserController_Constructor_Should_Set_Service()
        {
            //Arrange & Act
            var mockedService = new Mock<IUserService>();
            UserController controller = new UserController(mockedService.Object);

            //Assert
            Assert.AreEqual(mockedService.Object, controller.Service);
        }

        [Test]
        public void UserController_Index_Should_Call_Service_GetMyQuestions()
        {
            //Arrange
            var mockPrincipal = new Mock<IPrincipal>();
            mockPrincipal.SetupGet(p => p.Identity.Name).Returns("Pesho");
            mockPrincipal.Setup(p => p.IsInRole("User")).Returns(true);

            // create mock controller context
            var mockContext = new Mock<ControllerContext>();
            mockContext.SetupGet(p => p.HttpContext.User).Returns(mockPrincipal.Object);
            mockContext.SetupGet(p => p.HttpContext.Request.IsAuthenticated).Returns(true);

            var mockedService = new Mock<IUserService>();
            mockedService.Setup(s => s.GetMyQuestions(It.IsAny<string>()));
            mockedService.Setup(s => s.GetMyVotes(It.IsAny<string>()));
            UserController controller = new UserController(mockedService.Object)
            {
                ControllerContext = mockContext.Object
            };

            //Act
            controller.Index();

            //Assert
            mockedService.Verify(s => s.GetMyQuestions(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void UserController_Index_Should_Call_Service_GetMyVotes()
        {
            //Arrange
            var mockPrincipal = new Mock<IPrincipal>();
            mockPrincipal.SetupGet(p => p.Identity.Name).Returns("Pesho");
            mockPrincipal.Setup(p => p.IsInRole("User")).Returns(true);

            // create mock controller context
            var mockContext = new Mock<ControllerContext>();
            mockContext.SetupGet(p => p.HttpContext.User).Returns(mockPrincipal.Object);
            mockContext.SetupGet(p => p.HttpContext.Request.IsAuthenticated).Returns(true);

            var mockedService = new Mock<IUserService>();
            mockedService.Setup(s => s.GetMyQuestions(It.IsAny<string>()));
            mockedService.Setup(s => s.GetMyVotes(It.IsAny<string>()));
            UserController controller = new UserController(mockedService.Object)
            {
                ControllerContext = mockContext.Object
            };

            //Act
            controller.Index();

            //Assert
            mockedService.Verify(s => s.GetMyVotes(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void UserController_Index_Should_Return_ActionResult()
        {
            //Arrange
            var mockPrincipal = new Mock<IPrincipal>();
            mockPrincipal.SetupGet(p => p.Identity.Name).Returns("Pesho");
            mockPrincipal.Setup(p => p.IsInRole("User")).Returns(true);

            // create mock controller context
            var mockContext = new Mock<ControllerContext>();
            mockContext.SetupGet(p => p.HttpContext.User).Returns(mockPrincipal.Object);
            mockContext.SetupGet(p => p.HttpContext.Request.IsAuthenticated).Returns(true);

            var mockedService = new Mock<IUserService>();
            mockedService.Setup(s => s.GetMyQuestions(It.IsAny<string>()));
            mockedService.Setup(s => s.GetMyVotes(It.IsAny<string>()));
            UserController controller = new UserController(mockedService.Object)
            {
                ControllerContext = mockContext.Object
            };

            //Act
            var result = controller.Index();

            //Assert
            Assert.IsInstanceOf<ViewResult>(result);
        }

        [Test]
        public void UserController_Index_Should_Render_Default_View_With_Correct_Model()
        {
            //Arrange
            var mockPrincipal = new Mock<IPrincipal>();
            mockPrincipal.SetupGet(p => p.Identity.Name).Returns("Pesho");
            mockPrincipal.Setup(p => p.IsInRole("User")).Returns(true);

            // create mock controller context
            var mockContext = new Mock<ControllerContext>();
            mockContext.SetupGet(p => p.HttpContext.User).Returns(mockPrincipal.Object);
            mockContext.SetupGet(p => p.HttpContext.Request.IsAuthenticated).Returns(true);

            var mockedService = new Mock<IUserService>();
            mockedService.Setup(s => s.GetMyQuestions(It.IsAny<string>()));
            mockedService.Setup(s => s.GetMyVotes(It.IsAny<string>()));
            UserController controller = new UserController(mockedService.Object)
            {
                ControllerContext = mockContext.Object
            };

            //Act & Assert
            controller.WithCallTo(c => c.Index()).ShouldRenderDefaultView().WithModel<IndexViewModel>();
        }
    }
}
