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
using TestStack.FluentMVCTesting;

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
        public void QuestionController_Index_Should_Render_View_With_Correct_Model()
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

            //Act & Assert
            controller.WithCallTo(c => c.Index()).ShouldRenderDefaultView().WithModel<List<QuestionViewModel>>();
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
        public void QuestionsController_Create_Get_Should_Render_View()
        {
            //Arrange
            var mockedService = new Mock<IQuestionService>();
            MapperHelper helper = new MapperHelper();
            QuestionController controller = new QuestionController(mockedService.Object, helper);

            //Act & Assert
            controller.WithCallTo(c => c.Create()).ShouldRenderDefaultView();
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
        public void QuestionsController_GetDetailed_Should_Render_Default_View_With_Correct_Model()
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

            //Act & Assert
            controller.WithCallTo(c => c.GetDetailed(0)).ShouldRenderDefaultView().WithModel<QuestionViewModel>();
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
                Owner = user,
                Options = options
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
                UserName = "Pesho"
            };
            List<Option> options = new List<Option>()
            {
                new Option()
                {
                  Id = 1,
                  Description = "test",
                  Owner = user
                }
            };
            Question question = new Question()
            {
                Id = 0,
                Title = "test",
                Owner = user,
                Options = options
            };
            var mockedRepo = new Mock<IEfRepository<Question>>();
            mockedRepo.Setup(r => r.GetBy(It.IsAny<int>())).Returns(question);
            var mockedService = new Mock<IQuestionService>();
            mockedService.Setup(s => s.GetProvider.Questions).Returns(mockedRepo.Object);
            var helper = new MapperHelper();

            var mockPrincipal = new Mock<IPrincipal>();
            mockPrincipal.SetupGet(p => p.Identity.Name).Returns("Pesho");
            mockPrincipal.Setup(p => p.IsInRole("User")).Returns(true);

            // create mock controller context
            var mockContext = new Mock<ControllerContext>();
            mockContext.SetupGet(p => p.HttpContext.User).Returns(mockPrincipal.Object);
            mockContext.SetupGet(p => p.HttpContext.Request.IsAuthenticated).Returns(true);

            QuestionController controller = new QuestionController(mockedService.Object, helper)
            {
                ControllerContext = mockContext.Object
            };

            //Act
            var result = controller.CheckOption(0);

            //Assert
            Assert.AreEqual("Yes", result.Data);
        }

        [Test]
        public void QuestionController_CheckVote_Should_Call_Provider_Find_User_By_Username()
        {
            //Arrange
            ApplicationUser user = new ApplicationUser()
            {
                UserName = "Pesho"
            };
            var mockedProvider = new Mock<IEfSociumDataProvider>();
            mockedProvider.Setup(p => p.FindUserByUsername(It.IsAny<string>())).Returns(user);
            var mockedService = new Mock<IQuestionService>();
            mockedService.Setup(s => s.GetProvider).Returns(mockedProvider.Object);
            var helper = new MapperHelper();

            var mockPrincipal = new Mock<IPrincipal>();
            mockPrincipal.SetupGet(p => p.Identity.Name).Returns("Pesho");
            mockPrincipal.Setup(p => p.IsInRole("User")).Returns(true);

            // create mock controller context
            var mockContext = new Mock<ControllerContext>();
            mockContext.SetupGet(p => p.HttpContext.User).Returns(mockPrincipal.Object);
            mockContext.SetupGet(p => p.HttpContext.Request.IsAuthenticated).Returns(true);

            QuestionController controller = new QuestionController(mockedService.Object, helper)
            {
                ControllerContext = mockContext.Object
            };

            //Act
            controller.CheckVote(0);

            //Assert
            mockedProvider.Verify(p => p.FindUserByUsername(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void QuestionController_CheckVote_Should_Return_No()
        {
            //Arrange
            List<Vote> myVotes = new List<Vote>()
            {
                new Vote()
                {
                    QuestionId = 0
                }
            };
            ApplicationUser user = new ApplicationUser()
            {
                UserName = "Pesho",
                MyVotes = myVotes
            };
            var mockedProvider = new Mock<IEfSociumDataProvider>();
            mockedProvider.Setup(p => p.FindUserByUsername(It.IsAny<string>())).Returns(user);
            var mockedService = new Mock<IQuestionService>();
            mockedService.Setup(s => s.GetProvider).Returns(mockedProvider.Object);
            var helper = new MapperHelper();

            var mockPrincipal = new Mock<IPrincipal>();
            mockPrincipal.SetupGet(p => p.Identity.Name).Returns("Pesho");
            mockPrincipal.Setup(p => p.IsInRole("User")).Returns(true);

            // create mock controller context
            var mockContext = new Mock<ControllerContext>();
            mockContext.SetupGet(p => p.HttpContext.User).Returns(mockPrincipal.Object);
            mockContext.SetupGet(p => p.HttpContext.Request.IsAuthenticated).Returns(true);

            QuestionController controller = new QuestionController(mockedService.Object, helper)
            {
                ControllerContext = mockContext.Object
            };

            //Act
            var result = controller.CheckVote(1);

            //Assert
            Assert.AreEqual("No", result.Data);
        }

        [Test]
        public void QuestionController_CheckVote_Should_Return_Yes()
        {
            //Arrange
            List<Vote> myVotes = new List<Vote>()
            {
                new Vote()
                {
                    QuestionId = 0
                }
            };
            ApplicationUser user = new ApplicationUser()
            {
                UserName = "Pesho",
                MyVotes = myVotes
            };
            var mockedProvider = new Mock<IEfSociumDataProvider>();
            mockedProvider.Setup(p => p.FindUserByUsername(It.IsAny<string>())).Returns(user);
            var mockedService = new Mock<IQuestionService>();
            mockedService.Setup(s => s.GetProvider).Returns(mockedProvider.Object);
            var helper = new MapperHelper();

            var mockPrincipal = new Mock<IPrincipal>();
            mockPrincipal.SetupGet(p => p.Identity.Name).Returns("Pesho");
            mockPrincipal.Setup(p => p.IsInRole("User")).Returns(true);

            // create mock controller context
            var mockContext = new Mock<ControllerContext>();
            mockContext.SetupGet(p => p.HttpContext.User).Returns(mockPrincipal.Object);
            mockContext.SetupGet(p => p.HttpContext.Request.IsAuthenticated).Returns(true);

            QuestionController controller = new QuestionController(mockedService.Object, helper)
            {
                ControllerContext = mockContext.Object
            };

            //Act
            var result = controller.CheckVote(0);

            //Assert
            Assert.AreEqual("Yes", result.Data);
        }

        [Test]
        public void QuestionController_AddOption_Should_Call_Provider_GetUserByUsername()
        {
            //Arrange
            ApplicationUser user = new ApplicationUser()
            {
                UserName = "Pesho"
            };
            var mockedProvider = new Mock<IEfSociumDataProvider>();
            mockedProvider.Setup(p => p.FindUserByUsername(It.IsAny<string>())).Returns(user);
            var mockedService = new Mock<IQuestionService>();
            mockedService.Setup(s => s.GetProvider).Returns(mockedProvider.Object);
            var helper = new MapperHelper();

            var mockPrincipal = new Mock<IPrincipal>();
            mockPrincipal.SetupGet(p => p.Identity.Name).Returns("Pesho");
            mockPrincipal.Setup(p => p.IsInRole("User")).Returns(true);

            // create mock controller context
            var mockContext = new Mock<ControllerContext>();
            mockContext.SetupGet(p => p.HttpContext.User).Returns(mockPrincipal.Object);
            mockContext.SetupGet(p => p.HttpContext.Request.IsAuthenticated).Returns(true);

            QuestionController controller = new QuestionController(mockedService.Object, helper)
            {
                ControllerContext = mockContext.Object
            };

            //Act
            controller.AddOption("test", 0);

            //Assert
            mockedProvider.Verify(p => p.FindUserByUsername(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void QuestionController_AddOption_Should_Call_Service_AddOptionToQuestion()
        {
            //Arrange
            ApplicationUser user = new ApplicationUser()
            {
                UserName = "Pesho"
            };
            var mockedProvider = new Mock<IEfSociumDataProvider>();
            mockedProvider.Setup(p => p.FindUserByUsername(It.IsAny<string>())).Returns(user);
            var mockedService = new Mock<IQuestionService>();
            mockedService.Setup(s => s.GetProvider).Returns(mockedProvider.Object);
            mockedService.Setup(s => s.AddOptionToQuestion(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>()));
            var helper = new MapperHelper();

            var mockPrincipal = new Mock<IPrincipal>();
            mockPrincipal.SetupGet(p => p.Identity.Name).Returns("Pesho");
            mockPrincipal.Setup(p => p.IsInRole("User")).Returns(true);

            // create mock controller context
            var mockContext = new Mock<ControllerContext>();
            mockContext.SetupGet(p => p.HttpContext.User).Returns(mockPrincipal.Object);
            mockContext.SetupGet(p => p.HttpContext.Request.IsAuthenticated).Returns(true);

            QuestionController controller = new QuestionController(mockedService.Object, helper)
            {
                ControllerContext = mockContext.Object
            };

            //Act
            controller.AddOption("test", 0);

            //Assert
            mockedService.Verify(s => s.AddOptionToQuestion(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void QuestionController_AddOption_Should_Return_Success()
        {
            //Arrange
            ApplicationUser user = new ApplicationUser()
            {
                UserName = "Pesho"
            };
            var mockedProvider = new Mock<IEfSociumDataProvider>();
            mockedProvider.Setup(p => p.FindUserByUsername(It.IsAny<string>())).Returns(user);
            var mockedService = new Mock<IQuestionService>();
            mockedService.Setup(s => s.GetProvider).Returns(mockedProvider.Object);
            mockedService.Setup(s => s.AddOptionToQuestion(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>()));
            var helper = new MapperHelper();

            var mockPrincipal = new Mock<IPrincipal>();
            mockPrincipal.SetupGet(p => p.Identity.Name).Returns("Pesho");
            mockPrincipal.Setup(p => p.IsInRole("User")).Returns(true);

            // create mock controller context
            var mockContext = new Mock<ControllerContext>();
            mockContext.SetupGet(p => p.HttpContext.User).Returns(mockPrincipal.Object);
            mockContext.SetupGet(p => p.HttpContext.Request.IsAuthenticated).Returns(true);

            QuestionController controller = new QuestionController(mockedService.Object, helper)
            {
                ControllerContext = mockContext.Object
            };

            //Act
            var result = controller.AddOption("test", 0);

            //Assert
            Assert.AreEqual("success", result.Data);
        }

        [Test]
        public void QuestionController_Create_Should_Call_Provider_FindUserByUsername()
        {
            //Arrange
            QuestionViewModel model = new QuestionViewModel()
            {
                Id = 0,
                Title = "test"
            };
            ApplicationUser user = new ApplicationUser()
            {
                UserName = "Pesho"
            };
            var mockedProvider = new Mock<IEfSociumDataProvider>();
            mockedProvider.Setup(p => p.FindUserByUsername(It.IsAny<string>())).Returns(user);
            var mockedService = new Mock<IQuestionService>();
            mockedService.Setup(s => s.GetProvider).Returns(mockedProvider.Object);
            mockedService.Setup(s => s.Create(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()));
            var helper = new MapperHelper();

            var mockPrincipal = new Mock<IPrincipal>();
            mockPrincipal.SetupGet(p => p.Identity.Name).Returns("Pesho");
            mockPrincipal.Setup(p => p.IsInRole("User")).Returns(true);

            // create mock controller context
            var mockContext = new Mock<ControllerContext>();
            mockContext.SetupGet(p => p.HttpContext.User).Returns(mockPrincipal.Object);
            mockContext.SetupGet(p => p.HttpContext.Request.IsAuthenticated).Returns(true);

            QuestionController controller = new QuestionController(mockedService.Object, helper)
            {
                ControllerContext = mockContext.Object
            };

            //Act
            controller.Create("test", model);

            //Assert
            mockedProvider.Verify(p => p.FindUserByUsername(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void QuestionController_Create_Should_Call_Service_Create()
        {
            //Arrange
            QuestionViewModel model = new QuestionViewModel()
            {
                Id = 0,
                Title = "test"
            };
            ApplicationUser user = new ApplicationUser()
            {
                UserName = "Pesho"
            };
            var mockedProvider = new Mock<IEfSociumDataProvider>();
            mockedProvider.Setup(p => p.FindUserByUsername(It.IsAny<string>())).Returns(user);
            var mockedService = new Mock<IQuestionService>();
            mockedService.Setup(s => s.GetProvider).Returns(mockedProvider.Object);
            mockedService.Setup(s => s.Create(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()));
            var helper = new MapperHelper();

            var mockPrincipal = new Mock<IPrincipal>();
            mockPrincipal.SetupGet(p => p.Identity.Name).Returns("Pesho");
            mockPrincipal.Setup(p => p.IsInRole("User")).Returns(true);

            // create mock controller context
            var mockContext = new Mock<ControllerContext>();
            mockContext.SetupGet(p => p.HttpContext.User).Returns(mockPrincipal.Object);
            mockContext.SetupGet(p => p.HttpContext.Request.IsAuthenticated).Returns(true);

            QuestionController controller = new QuestionController(mockedService.Object, helper)
            {
                ControllerContext = mockContext.Object
            };

            //Act
            controller.Create("test", model);

            //Assert
            mockedService.Verify(s => s.Create(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void QuestionController_Create_Should_Redirect_To_View()
        {
            //Arrange
            QuestionViewModel model = new QuestionViewModel()
            {
                Id = 0,
                Title = "test"
            };
            ApplicationUser user = new ApplicationUser()
            {
                UserName = "Pesho"
            };
            var mockedProvider = new Mock<IEfSociumDataProvider>();
            mockedProvider.Setup(p => p.FindUserByUsername(It.IsAny<string>())).Returns(user);
            var mockedService = new Mock<IQuestionService>();
            mockedService.Setup(s => s.GetProvider).Returns(mockedProvider.Object);
            mockedService.Setup(s => s.Create(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()));
            var helper = new MapperHelper();

            var mockPrincipal = new Mock<IPrincipal>();
            mockPrincipal.SetupGet(p => p.Identity.Name).Returns("Pesho");
            mockPrincipal.Setup(p => p.IsInRole("User")).Returns(true);

            // create mock controller context
            var mockContext = new Mock<ControllerContext>();
            mockContext.SetupGet(p => p.HttpContext.User).Returns(mockPrincipal.Object);
            mockContext.SetupGet(p => p.HttpContext.Request.IsAuthenticated).Returns(true);

            QuestionController controller = new QuestionController(mockedService.Object, helper)
            {
                ControllerContext = mockContext.Object
            };

            //Act
            controller.WithCallTo(c => c.Create("test", model)).ShouldRedirectTo(c => c.Index());
        }
    }
}
