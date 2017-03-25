using Moq;
using NUnit.Framework;
using PagedList;
using SociumApp.Areas.Admin.Controllers;
using SociumApp.Areas.Admin.Models;
using SociumApp.Data.Contracts;
using SociumApp.Models;
using SociumApp.Services;
using SociumApp.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using TestStack.FluentMVCTesting;

namespace SociumApp.Tests.WebClient.Tests.Controllers.Tests.Admin.Tests
{
    [TestFixture]
    public class AdminControllerTests
    {
        [Test]
        public void AdminController_Constructor_Should_Initialize_Object()
        {
            //Arrange & Act
            var mockedService = new Mock<IAdminService>();
            AdministratorController controller = new AdministratorController(mockedService.Object);

            //Assert
            Assert.IsInstanceOf<AdministratorController>(controller);
        }

        [Test]
        public void AdminController_Constructor_Should_Set_Service()
        {
            //Arrange & Act
            var mockedService = new Mock<IAdminService>();
            AdministratorController controller = new AdministratorController(mockedService.Object);

            //Assert
            Assert.AreSame(mockedService.Object, controller.Service);
        }

        [Test]
        public void AdminController_Index_Should_Return_ViewResult()
        {
            //Arrange
            var mockedService = new Mock<IAdminService>();
            AdministratorController controller = new AdministratorController(mockedService.Object);

            //Act
            var result = controller.Index();

            //Assert
            Assert.IsInstanceOf<ViewResult>(result);
        }

        [Test]
        public void AdminController_Index_Should_Render_Default_View_With_Correct_Model()
        {
            //Arrange
            var mockedService = new Mock<IAdminService>();
            AdministratorController controller = new AdministratorController(mockedService.Object);

            //Act & Assert
            controller.WithCallTo(c => c.Index()).ShouldRenderDefaultView().WithModel<IndexAdminViewModel>();
        }

        [Test]
        public void AdminController_UsersStatistic_Should_Call_RepoUsers_GetAll()
        {
            //Arrange
            List<ApplicationUser> users = new List<ApplicationUser>();
            var mockedRepo = new Mock<IEfRepository<ApplicationUser>>();
            mockedRepo.Setup(r => r.GetAll()).Returns(users.AsQueryable());
            var mockedProvider = new Mock<IEfSociumDataProvider>();
            mockedProvider.Setup(p => p.Users).Returns(mockedRepo.Object);
            var mockedService = new Mock<IAdminService>();
            mockedService.Setup(s => s.GetProvider).Returns(mockedProvider.Object);
            AdministratorController controller = new AdministratorController(mockedService.Object);

            //Act
            controller.UsersStatistic(1, 0);
            controller.UsersStatistic(1, 1);
            controller.UsersStatistic(1, 2);

            //Assert
            mockedRepo.Verify(r => r.GetAll(), Times.Exactly(6));
        }

        [Test]
        public void AdminController_UsersStatistic_Should_Return_View_Result()
        {
            //Arrange
            List<ApplicationUser> users = new List<ApplicationUser>();
            var mockedRepo = new Mock<IEfRepository<ApplicationUser>>();
            mockedRepo.Setup(r => r.GetAll()).Returns(users.AsQueryable());
            var mockedProvider = new Mock<IEfSociumDataProvider>();
            mockedProvider.Setup(p => p.Users).Returns(mockedRepo.Object);
            var mockedService = new Mock<IAdminService>();
            mockedService.Setup(s => s.GetProvider).Returns(mockedProvider.Object);
            AdministratorController controller = new AdministratorController(mockedService.Object);

            //Act
            var result = controller.UsersStatistic(1, 0);

            //Assert
            Assert.IsInstanceOf<ViewResult>(result);
        }

        [Test]
        public void AdminController_UsersStatistic_Should_Render_Default_View_With_Correct_Model()
        {
            //Arrange
            List<ApplicationUser> users = new List<ApplicationUser>();
            var mockedRepo = new Mock<IEfRepository<ApplicationUser>>();
            mockedRepo.Setup(r => r.GetAll()).Returns(users.AsQueryable());
            var mockedProvider = new Mock<IEfSociumDataProvider>();
            mockedProvider.Setup(p => p.Users).Returns(mockedRepo.Object);
            var mockedService = new Mock<IAdminService>();
            mockedService.Setup(s => s.GetProvider).Returns(mockedProvider.Object);
            AdministratorController controller = new AdministratorController(mockedService.Object);

            //Act & Assert
            controller.WithCallTo(c => c.UsersStatistic(1, 0)).ShouldRenderDefaultView().WithModel<IPagedList<ApplicationUser>>();
        }

        [Test]
        public void AdminController_QuestionsStatistic_Should_Call_RepoQuestions_GetAll()
        {
            //Arrange
            List<Question> questions = new List<Question>();
            var mockedRepo = new Mock<IEfRepository<Question>>();
            mockedRepo.Setup(r => r.GetAll()).Returns(questions.AsQueryable());
            var mockedProvider = new Mock<IEfSociumDataProvider>();
            mockedProvider.Setup(p => p.Questions).Returns(mockedRepo.Object);
            var mockedService = new Mock<IAdminService>();
            mockedService.Setup(s => s.GetProvider).Returns(mockedProvider.Object);
            AdministratorController controller = new AdministratorController(mockedService.Object);

            //Act
            controller.QuestionsStatistic(1, 0);
            controller.QuestionsStatistic(1, 1);
            controller.QuestionsStatistic(1, 2);

            //Assert
            mockedRepo.Verify(r => r.GetAll(), Times.Exactly(6));
        }

        [Test]
        public void AdminController_QuestionsStatistic_Should_Return_View_Result()
        {
            //Arrange
            List<Question> questions = new List<Question>();
            var mockedRepo = new Mock<IEfRepository<Question>>();
            mockedRepo.Setup(r => r.GetAll()).Returns(questions.AsQueryable());
            var mockedProvider = new Mock<IEfSociumDataProvider>();
            mockedProvider.Setup(p => p.Questions).Returns(mockedRepo.Object);
            var mockedService = new Mock<IAdminService>();
            mockedService.Setup(s => s.GetProvider).Returns(mockedProvider.Object);
            AdministratorController controller = new AdministratorController(mockedService.Object);

            //Act
            var result = controller.QuestionsStatistic(1, 0);

            //Assert
            Assert.IsInstanceOf<ViewResult>(result);
        }

        [Test]
        public void AdminController_QuestionsStatistic_Should_Render_Default_View_With_Correct_Model()
        {
            //Arrange
            List<Question> questions = new List<Question>();
            var mockedRepo = new Mock<IEfRepository<Question>>();
            mockedRepo.Setup(r => r.GetAll()).Returns(questions.AsQueryable());
            var mockedProvider = new Mock<IEfSociumDataProvider>();
            mockedProvider.Setup(p => p.Questions).Returns(mockedRepo.Object);
            var mockedService = new Mock<IAdminService>();
            mockedService.Setup(s => s.GetProvider).Returns(mockedProvider.Object);
            AdministratorController controller = new AdministratorController(mockedService.Object);

            //Act & Assert
            controller.WithCallTo(c => c.QuestionsStatistic(1, 0)).ShouldRenderDefaultView().WithModel<IPagedList<Question>>();
        }

        [Test]
        public void AdminController_OptionsStatistic_Should_Call_RepoOptions_GetAll()
        {
            //Arrange
            List<Option> options = new List<Option>();
            var mockedRepo = new Mock<IEfRepository<Option>>();
            mockedRepo.Setup(r => r.GetAll()).Returns(options.AsQueryable());
            var mockedProvider = new Mock<IEfSociumDataProvider>();
            mockedProvider.Setup(p => p.Options).Returns(mockedRepo.Object);
            var mockedService = new Mock<IAdminService>();
            mockedService.Setup(s => s.GetProvider).Returns(mockedProvider.Object);
            AdministratorController controller = new AdministratorController(mockedService.Object);

            //Act
            controller.OptionsStatistic(1, 0);
            controller.OptionsStatistic(1, 1);
            controller.OptionsStatistic(1, 2);

            //Assert
            mockedRepo.Verify(r => r.GetAll(), Times.Exactly(6));
        }

        [Test]
        public void AdminController_OptionsStatistic_Should_Return_View_Result()
        {
            //Arrange
            List<Option> options = new List<Option>();
            var mockedRepo = new Mock<IEfRepository<Option>>();
            mockedRepo.Setup(r => r.GetAll()).Returns(options.AsQueryable());
            var mockedProvider = new Mock<IEfSociumDataProvider>();
            mockedProvider.Setup(p => p.Options).Returns(mockedRepo.Object);
            var mockedService = new Mock<IAdminService>();
            mockedService.Setup(s => s.GetProvider).Returns(mockedProvider.Object);
            AdministratorController controller = new AdministratorController(mockedService.Object);

            //Act
            var result = controller.OptionsStatistic(1, 0);

            //Assert
            Assert.IsInstanceOf<ViewResult>(result);
        }

        [Test]
        public void AdminController_OptionsStatistic_Should_Render_Default_View_With_Correct_Model()
        {
            //Arrange
            List<Option> options = new List<Option>();
            var mockedRepo = new Mock<IEfRepository<Option>>();
            mockedRepo.Setup(r => r.GetAll()).Returns(options.AsQueryable());
            var mockedProvider = new Mock<IEfSociumDataProvider>();
            mockedProvider.Setup(p => p.Options).Returns(mockedRepo.Object);
            var mockedService = new Mock<IAdminService>();
            mockedService.Setup(s => s.GetProvider).Returns(mockedProvider.Object);
            AdministratorController controller = new AdministratorController(mockedService.Object);

            //Act & Assert
            controller.WithCallTo(c => c.OptionsStatistic(1, 0)).ShouldRenderDefaultView().WithModel<IPagedList<Option>>();
        }

        [Test]
        public void AdminController_VotesStatistic_Should_Call_RepoOptions_GetAll()
        {
            //Arrange
            List<Vote> votes = new List<Vote>();
            var mockedRepo = new Mock<IEfRepository<Vote>>();
            mockedRepo.Setup(r => r.GetAll()).Returns(votes.AsQueryable());
            var mockedProvider = new Mock<IEfSociumDataProvider>();
            mockedProvider.Setup(p => p.Votes).Returns(mockedRepo.Object);
            var mockedService = new Mock<IAdminService>();
            mockedService.Setup(s => s.GetProvider).Returns(mockedProvider.Object);
            AdministratorController controller = new AdministratorController(mockedService.Object);

            //Act
            controller.VotesStatistic(1, 0);
            controller.VotesStatistic(1, 1);
            controller.VotesStatistic(1, 2);

            //Assert
            mockedRepo.Verify(r => r.GetAll(), Times.Exactly(6));
        }

        [Test]
        public void AdminController_VotesStatistic_Should_Return_View_Result()
        {
            //Arrange
            List<Vote> votes = new List<Vote>();
            var mockedRepo = new Mock<IEfRepository<Vote>>();
            mockedRepo.Setup(r => r.GetAll()).Returns(votes.AsQueryable());
            var mockedProvider = new Mock<IEfSociumDataProvider>();
            mockedProvider.Setup(p => p.Votes).Returns(mockedRepo.Object);
            var mockedService = new Mock<IAdminService>();
            mockedService.Setup(s => s.GetProvider).Returns(mockedProvider.Object);
            AdministratorController controller = new AdministratorController(mockedService.Object);

            //Act
            var result = controller.VotesStatistic(1, 0);

            //Assert
            Assert.IsInstanceOf<ViewResult>(result);
        }

        [Test]
        public void AdminController_VotesStatistic_Should_Render_Default_View_With_Correct_Model()
        {
            //Arrange
            List<Vote> votes = new List<Vote>();
            var mockedRepo = new Mock<IEfRepository<Vote>>();
            mockedRepo.Setup(r => r.GetAll()).Returns(votes.AsQueryable());
            var mockedProvider = new Mock<IEfSociumDataProvider>();
            mockedProvider.Setup(p => p.Votes).Returns(mockedRepo.Object);
            var mockedService = new Mock<IAdminService>();
            mockedService.Setup(s => s.GetProvider).Returns(mockedProvider.Object);
            AdministratorController controller = new AdministratorController(mockedService.Object);

            //Act & Assert
            controller.WithCallTo(c => c.VotesStatistic(1, 0)).ShouldRenderDefaultView().WithModel<IPagedList<Vote>>();
        }
    }
}
