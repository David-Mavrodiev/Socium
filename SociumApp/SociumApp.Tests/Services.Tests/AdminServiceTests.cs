using Moq;
using NUnit.Framework;
using SociumApp.Data.Contracts;
using SociumApp.Models;
using SociumApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SociumApp.Tests.Services.Tests
{
    [TestFixture]
    public class AdminServiceTests
    {
        [Test]
        public void AdminService_Constructor_Should_Initialize_Object()
        {
            //Arrange & Act
            var mockedProvider = new Mock<IEfSociumDataProvider>();
            AdminService service = new AdminService(mockedProvider.Object);

            //Assert
            Assert.IsInstanceOf<AdminService>(service);
        }

        [Test]
        public void AdminService_Should_Set_Provider()
        {
            //Arrange & Act
            var mockedProvider = new Mock<IEfSociumDataProvider>();
            AdminService service = new AdminService(mockedProvider.Object);

            //Assert
            Assert.AreEqual(mockedProvider.Object, service.GetProvider);
        }

        [Test]
        public void AdminService_Should_Call_Users_GetAll()
        {
            //Arrange
            List<ApplicationUser> users = new List<ApplicationUser>();
            var mockedRepo = new Mock<IEfRepository<ApplicationUser>>();
            mockedRepo.Setup(r => r.GetAll()).Returns(users.AsQueryable());
            var mockedProvider = new Mock<IEfSociumDataProvider>();
            mockedProvider.Setup(p => p.Users).Returns(mockedRepo.Object);
            AdminService service = new AdminService(mockedProvider.Object);

            //Act
            var result = service.GetAllUsersCount();

            //Assert
            mockedRepo.Verify(r => r.GetAll(), Times.Once);
        }

        [Test]
        public void AdminService_Should_Return_Correct_Users_Count()
        {
            //Arrange
            List<ApplicationUser> users = new List<ApplicationUser>()
            {
                new ApplicationUser()
            };
            var mockedRepo = new Mock<IEfRepository<ApplicationUser>>();
            mockedRepo.Setup(r => r.GetAll()).Returns(users.AsQueryable());
            var mockedProvider = new Mock<IEfSociumDataProvider>();
            mockedProvider.Setup(p => p.Users).Returns(mockedRepo.Object);
            AdminService service = new AdminService(mockedProvider.Object);

            //Act
            var result = service.GetAllUsersCount();

            //Assert
            Assert.IsTrue(result > 0);
        }

        [Test]
        public void AdminService_Should_Call_Questions_GetAll()
        {
            //Arrange
            List<Question> questions = new List<Question>();
            var mockedRepo = new Mock<IEfRepository<Question>>();
            mockedRepo.Setup(r => r.GetAll()).Returns(questions.AsQueryable());
            var mockedProvider = new Mock<IEfSociumDataProvider>();
            mockedProvider.Setup(p => p.Questions).Returns(mockedRepo.Object);
            AdminService service = new AdminService(mockedProvider.Object);

            //Act
            var result = service.GetAllQuestionsCount();

            //Assert
            mockedRepo.Verify(r => r.GetAll(), Times.Once);
        }

        [Test]
        public void AdminService_Should_Return_Correct_Questions_Count()
        {
            //Arrange
            List<Question> questions = new List<Question>()
            {
                new Question()
            };
            var mockedRepo = new Mock<IEfRepository<Question>>();
            mockedRepo.Setup(r => r.GetAll()).Returns(questions.AsQueryable());
            var mockedProvider = new Mock<IEfSociumDataProvider>();
            mockedProvider.Setup(p => p.Questions).Returns(mockedRepo.Object);
            AdminService service = new AdminService(mockedProvider.Object);

            //Act
            var result = service.GetAllQuestionsCount();

            //Assert
            Assert.IsTrue(result > 0);
        }

        [Test]
        public void AdminService_Should_Call_Options_GetAll()
        {
            //Arrange
            List<Option> options = new List<Option>();
            var mockedRepo = new Mock<IEfRepository<Option>>();
            mockedRepo.Setup(r => r.GetAll()).Returns(options.AsQueryable());
            var mockedProvider = new Mock<IEfSociumDataProvider>();
            mockedProvider.Setup(p => p.Options).Returns(mockedRepo.Object);
            AdminService service = new AdminService(mockedProvider.Object);

            //Act
            var result = service.GetAllOptionsCount();

            //Assert
            mockedRepo.Verify(r => r.GetAll(), Times.Once);
        }

        [Test]
        public void AdminService_Should_Return_Correct_Options_Count()
        {
            //Arrange
            List<Option> options = new List<Option>()
            {
                new Option()
            };
            var mockedRepo = new Mock<IEfRepository<Option>>();
            mockedRepo.Setup(r => r.GetAll()).Returns(options.AsQueryable());
            var mockedProvider = new Mock<IEfSociumDataProvider>();
            mockedProvider.Setup(p => p.Options).Returns(mockedRepo.Object);
            AdminService service = new AdminService(mockedProvider.Object);

            //Act
            var result = service.GetAllOptionsCount();

            //Assert
            Assert.IsTrue(result > 0);
        }

        [Test]
        public void AdminService_Should_Call_Votes_GetAll()
        {
            //Arrange
            List<Vote> votes = new List<Vote>();
            var mockedRepo = new Mock<IEfRepository<Vote>>();
            mockedRepo.Setup(r => r.GetAll()).Returns(votes.AsQueryable());
            var mockedProvider = new Mock<IEfSociumDataProvider>();
            mockedProvider.Setup(p => p.Votes).Returns(mockedRepo.Object);
            AdminService service = new AdminService(mockedProvider.Object);

            //Act
            var result = service.GetAllVotesCount();

            //Assert
            mockedRepo.Verify(r => r.GetAll(), Times.Once);
        }

        [Test]
        public void AdminService_Should_Return_Correct_Votes_Count()
        {
            //Arrange
            List<Vote> votes = new List<Vote>()
            {
                new Vote()
            };
            var mockedRepo = new Mock<IEfRepository<Vote>>();
            mockedRepo.Setup(r => r.GetAll()).Returns(votes.AsQueryable());
            var mockedProvider = new Mock<IEfSociumDataProvider>();
            mockedProvider.Setup(p => p.Votes).Returns(mockedRepo.Object);
            AdminService service = new AdminService(mockedProvider.Object);

            //Act
            var result = service.GetAllVotesCount();

            //Assert
            Assert.IsTrue(result > 0);
        }
    }
}
