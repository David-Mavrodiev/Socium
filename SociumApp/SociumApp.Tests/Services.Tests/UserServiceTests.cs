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
    public class UserServiceTests
    {
        [Test]
        public void UserService_Constructor_Should_Initialize_Object()
        {
            //Arrange & Act
            var mockedProvider = new Mock<IEfSociumDataProvider>();
            UserService service = new UserService(mockedProvider.Object);

            //Assert
            Assert.IsInstanceOf<UserService>(service);
        }

        [Test]
        public void UserService_Should_Set_Provider()
        {
            //Arrange & Act
            var mockedProvider = new Mock<IEfSociumDataProvider>();
            UserService service = new UserService(mockedProvider.Object);

            //Assert
            Assert.AreEqual(mockedProvider.Object, service.GetProvider);
        }

        [Test]
        public void UserService_GetMyQuestions_Should_Work()
        {
            //Arrange
            List<Question> questions = new List<Question>();
            ApplicationUser user = new ApplicationUser()
            {
                 MyQuestions = questions
            };
            var mockedProvider = new Mock<IEfSociumDataProvider>();
            mockedProvider.Setup(p => p.FindUserByUsername(It.IsAny<string>())).Returns(user);
            UserService service = new UserService(mockedProvider.Object);

            //Act
            var result = service.GetMyQuestions("test");

            //Assert
            Assert.AreEqual(questions, result);
        }

        [Test]
        public void UserService_GetMyVotes_Should_Work()
        {
            //Arrange
            List<Vote> votes = new List<Vote>();
            ApplicationUser user = new ApplicationUser()
            {
                MyVotes = votes
            };
            var mockedProvider = new Mock<IEfSociumDataProvider>();
            mockedProvider.Setup(p => p.FindUserByUsername(It.IsAny<string>())).Returns(user);
            UserService service = new UserService(mockedProvider.Object);

            //Act
            var result = service.GetMyVotes("test");

            //Assert
            Assert.AreEqual(votes, result);
        }
    }
}
