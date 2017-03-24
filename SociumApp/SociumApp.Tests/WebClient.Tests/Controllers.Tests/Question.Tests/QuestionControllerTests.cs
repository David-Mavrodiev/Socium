using Moq;
using NUnit.Framework;
using SociumApp.Controllers;
using SociumApp.Data.Contracts;
using SociumApp.Helpers;
using SociumApp.Models;
using SociumApp.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SociumApp.Tests.WebClient.Tests.Controllers.Tests.QuestionTests
{
    [TestFixture]
    public class QuestionControllerTests
    {
        [Test]
        public void QuestionController_Constructor_Should_Initialize_Object()
        {
            //Arrange & Act
            var mockedService = new Mock<IQuestionService>();
            MapperHelper helper = new MapperHelper(); 
            QuestionController controller = new QuestionController(mockedService.Object, helper);

            //Assert
            Assert.IsInstanceOf<QuestionController>(controller);
        }

        [Test]
        public void QuestionController_Constructor_Should_Set_Service()
        {
            //Arrange & Act
            var mockedService = new Mock<IQuestionService>();
            MapperHelper helper = new MapperHelper();
            QuestionController controller = new QuestionController(mockedService.Object, helper);

            //Assert
            Assert.IsInstanceOf<IQuestionService>(controller.Service);
        }

        [Test]
        public void QuestionController_Constructor_Should_Set_Helper()
        {
            //Arrange & Act
            var mockedService = new Mock<IQuestionService>();
            MapperHelper helper = new MapperHelper();
            QuestionController controller = new QuestionController(mockedService.Object, helper);

            //Assert
            Assert.IsInstanceOf<MapperHelper>(controller.Helper);
        }

        [Test]
        public void QuestionController_Index_Should_Call_Service_GetAll()
        {
            //Arrange
            ApplicationUser user = new ApplicationUser()
            {
                Id = "0",
                UserName = "test"
            };
            List<Option> options = new List<Option>()
            {
               new Option()
               {
                   Id = 0,
                   Description = "test",
                   OwnerId = "0",
                   QuestionId = 0,
                   Owner = user
               }
            };
            List<Question> questions = new List<Question>()
            {
                new Question()
                {
                   Id = 0,
                   Title = "test",
                   OwnerId = "test",
                   Options = options,
                   Owner = user
                }
            };
            var mockedService = new Mock<IQuestionService>();
            mockedService.Setup(s => s.GetAll()).Returns(questions);
            MapperHelper helper = new MapperHelper();
            QuestionController controller = new QuestionController(mockedService.Object, helper);

            //Act
            controller.Index();

            //Assert
            mockedService.Verify(s => s.GetAll(), Times.Once);
        }

        [Test]
        public void QuestionController_Index_Should_Return_Action_View()
        {
            //Arrange
            ApplicationUser user = new ApplicationUser()
            {
                Id = "0",
                UserName = "test"
            };
            List<Option> options = new List<Option>()
            {
               new Option()
               {
                   Id = 0,
                   Description = "test",
                   OwnerId = "0",
                   QuestionId = 0,
                   Owner = user
               }
            };
            List<Question> questions = new List<Question>()
            {
                new Question()
                {
                   Id = 0,
                   Title = "test",
                   OwnerId = "test",
                   Options = options,
                   Owner = user
                }
            };
            var mockedService = new Mock<IQuestionService>();
            mockedService.Setup(s => s.GetAll()).Returns(questions);
            MapperHelper helper = new MapperHelper();
            QuestionController controller = new QuestionController(mockedService.Object, helper);

            //Act
            var result = controller.Index();

            //Assert
            Assert.IsInstanceOf<ViewResult>(result);
        }

        [Test]
        public void QuestionsController_Create_Get_Should_Return_View()
        {
            //Arrange
            var mockedService = new Mock<IQuestionService>();
            MapperHelper helper = new MapperHelper();
            QuestionController controller = new QuestionController(mockedService.Object, helper);

            //Act
            var result = controller.Create();

            //Assert
            Assert.IsInstanceOf<ViewResult>(result);
        }

        [Test]
        public void QuestionsController_GetDetailed_Should_Call_GetId()
        {
            //Arrange
            ApplicationUser user = new ApplicationUser()
            {
                 Id = "0",
                 UserName = "test"
            };
            List<Option> options = new List<Option>()
            {
                new Option()
                {
                  Id = 1,
                  Description = "test",
                  OwnerId = "0",
                  Owner = user
                }
            };
            Question question = new Question()
            {
                Id = 0,
                Title = "test",
                OwnerId = "0" ,
                Owner = user
            };
            var mockedService = new Mock<IQuestionService>();
            mockedService.Setup(s => s.GetById(It.IsAny<int>())).Returns(question);
            MapperHelper helper = new MapperHelper();
            QuestionController controller = new QuestionController(mockedService.Object, helper);

            //Act
            var result = controller.GetDetailed(0);

            //Assert
            mockedService.Verify(s => s.GetById(It.IsAny<int>()), Times.Once);
        }

        [Test]
        public void QuestionsController_GetDetailed_Should_Return_Action_Result()
        {
            //Arrange
            ApplicationUser user = new ApplicationUser()
            {
                Id = "0",
                UserName = "test"
            };
            List<Option> options = new List<Option>()
            {
                new Option()
                {
                  Id = 1,
                  Description = "test",
                  OwnerId = "0",
                  Owner = user
                }
            };
            Question question = new Question()
            {
                Id = 0,
                Title = "test",
                OwnerId = "0",
                Owner = user
            };
            var mockedService = new Mock<IQuestionService>();
            mockedService.Setup(s => s.GetById(It.IsAny<int>())).Returns(question);
            MapperHelper helper = new MapperHelper();
            QuestionController controller = new QuestionController(mockedService.Object, helper);

            //Act
            var result = controller.GetDetailed(0);

            //Assert
            Assert.IsInstanceOf<ViewResult>(result);
        }

        [Test]
        public void QuestionController_CheckOption_Should_Call_GetBy()
        {
            //Arrange
            ApplicationUser user = new ApplicationUser()
            {
                Id = "0",
                UserName = "test"
            };
            List<Option> options = new List<Option>()
            {
                new Option()
                {
                  Id = 1,
                  Description = "test",
                  OwnerId = "0",
                  Owner = user
                }
            };
            Question question = new Question()
            {
                Id = 0,
                Title = "test",
                OwnerId = "0",
                Owner = user
            };
            var mockedRepo = new Mock<IEfRepository<Question>>();
            mockedRepo.Setup(r => r.GetBy(It.IsAny<int>())).Returns(question);
            var mockedService = new Mock<IQuestionService>();
            mockedService.Setup(s => s.GetProvider.Questions).Returns(mockedRepo.Object);
            var helper = new MapperHelper();
            var fakeHttpContext = new Mock<HttpContextBase>();
            var fakeIdentity = new GenericIdentity("User");
            var principal = new GenericPrincipal(fakeIdentity, null);

            fakeHttpContext.Setup(t => t.User).Returns(principal);
            var controllerContext = new Mock<ControllerContext>();
            controllerContext.Setup(t => t.HttpContext).Returns(fakeHttpContext.Object);

            QuestionController controller = new QuestionController(mockedService.Object, helper);

            controller.ControllerContext = controllerContext.Object;

            //Act
            controller.CheckOption(0);

            //Assert
            mockedRepo.Verify(r => r.GetBy(It.IsAny<int>()), Times.Once);
        }

        [Test]
        public void QuestionController_CheckOption_Should_Return_Json_No()
        {
            //Arrange
            ApplicationUser user = new ApplicationUser()
            {
                Id = "0",
                UserName = "test"
            };
            List<Option> options = new List<Option>()
            {
                new Option()
                {
                  Id = 1,
                  Description = "test",
                  OwnerId = "0",
                  Owner = user
                }
            };
            Question question = new Question()
            {
                Id = 0,
                Title = "test",
                OwnerId = "0",
                Owner = user
            };
            var mockedRepo = new Mock<IEfRepository<Question>>();
            mockedRepo.Setup(r => r.GetBy(It.IsAny<int>())).Returns(question);
            var mockedService = new Mock<IQuestionService>();
            mockedService.Setup(s => s.GetProvider.Questions).Returns(mockedRepo.Object);
            var helper = new MapperHelper();
            var fakeHttpContext = new Mock<HttpContextBase>();
            var fakeIdentity = new GenericIdentity("User");
            var principal = new GenericPrincipal(fakeIdentity, null);

            fakeHttpContext.Setup(t => t.User).Returns(principal);
            var controllerContext = new Mock<ControllerContext>();
            controllerContext.Setup(t => t.HttpContext).Returns(fakeHttpContext.Object);

            QuestionController controller = new QuestionController(mockedService.Object, helper);

            controller.ControllerContext = controllerContext.Object;

            //Act
            var result = controller.CheckOption(0);

            //Assert
            Assert.AreEqual("No", result.Data);
        }

        [Test]
        public void QuestionController_CheckOption_Should_Return_Json_Yes()
        {
            //Arrange
            ApplicationUser user = new ApplicationUser()
            {
                Id = "0",
                UserName = "test"
            };
            List<Option> options = new List<Option>()
            {
                new Option()
                {
                  Id = 1,
                  Description = "test",
                  OwnerId = "0",
                  Owner = user
                }
            };
            Question question = new Question()
            {
                Id = 0,
                Title = "test",
                OwnerId = "0",
                Owner = user
            };
            var mockedRepo = new Mock<IEfRepository<Question>>();
            mockedRepo.Setup(r => r.GetBy(It.IsAny<int>())).Returns(question);
            var mockedService = new Mock<IQuestionService>();
            mockedService.Setup(s => s.GetProvider.Questions).Returns(mockedRepo.Object);
            var helper = new MapperHelper();
            var fakeHttpContext = new Mock<HttpContextBase>();
            var fakeIdentity = new GenericIdentity("User");
            var principal = new GenericPrincipal(fakeIdentity, null);

            fakeHttpContext.Setup(t => t.User).Returns(principal);
            var controllerContext = new Mock<ControllerContext>();
            controllerContext.Setup(t => t.HttpContext).Returns(fakeHttpContext.Object);

            QuestionController controller = new QuestionController(mockedService.Object, helper);

            controller.ControllerContext = controllerContext.Object;

            //Act
            var result = controller.CheckOption(0);

            //Assert
            Assert.AreEqual("No", result.Data);
        }
    }
}
