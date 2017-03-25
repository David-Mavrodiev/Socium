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
    public class ChatServiceTests
    {
        [Test]
        public void ChatService_Constructor_Should_Return_Object()
        {
            //Arrange & Act
            var mockedProvider = new Mock<IEfSociumDataProvider>();
            ChatService service = new ChatService(mockedProvider.Object);

            //Assert
            Assert.IsInstanceOf<ChatService>(service);
        }

        [Test]
        public void ChatService_Constructor_Should_Set_provider()
        {
            //Arrange & Act
            var mockedProvider = new Mock<IEfSociumDataProvider>();
            ChatService service = new ChatService(mockedProvider.Object);

            //Assert
            Assert.AreSame(mockedProvider.Object, service.GetProvider);
        }

        [Test]
        public void ChatService_FindAnswerByQuestions_Should_Throw()
        {
            //Arrange
            var mockedProvider = new Mock<IEfSociumDataProvider>();
            ChatService service = new ChatService(mockedProvider.Object);

            //Act & Assert
            Assert.Throws<NullReferenceException>(() => service.FindAnswerByQuestion("test"));
        }

        [Test]
        public void ChatService_FindAnswerByQuestions_Should_Work_Correct()
        {
            //Arrange
            List<Vote> votes = new List<Vote>();
            List<Option> options = new List<Option>() { new Option { Votes = votes } };
            var mockedProvider = new Mock<IEfSociumDataProvider>();
            IEnumerable<Question> enumerable = new Question[1] { new Question() { Title="test test test", Id = 12, Options = options } };
            mockedProvider.Setup(p => p.Questions.GetAll()).Returns(enumerable.AsQueryable());
            ChatService service = new ChatService(mockedProvider.Object);

            //Act
            var result = service.FindAnswerByQuestion("drugo");

            //Assert
            Assert.AreEqual(result, "Нямам отговор на въпроса. Направи анкета! :-)");
        }

        [Test]
        public void ChatService_FindAnswerByQuestions_Should_Return_Description()
        {
            //Arrange
            string description = "test test test";
            List<Vote> votes = new List<Vote>();
            List<Option> options = new List<Option>() { new Option { Votes = votes, Description = description } };
            var mockedProvider = new Mock<IEfSociumDataProvider>();
            IEnumerable<Question> enumerable = new Question[1] { new Question() { Title = "test test test", Id = 12, Options = options } };
            mockedProvider.Setup(p => p.Questions.GetAll()).Returns(enumerable.AsQueryable());
            ChatService service = new ChatService(mockedProvider.Object);

            //Act
            var result = service.FindAnswerByQuestion("test");

            //Assert
            Assert.AreEqual(description, result);
        }
    }
}
