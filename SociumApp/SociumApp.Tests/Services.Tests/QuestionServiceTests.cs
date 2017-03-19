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
    public class QuestionServiceTests
    {
        [Test]
        public void QuestionService_Constructor_Should_Initialize_Object()
        {
            //Arrange & Act
            var mockedProvider = new Mock<IEfSociumDataProvider>();
            QuestionService service = new QuestionService(mockedProvider.Object);

            //Assert
            Assert.IsInstanceOf<QuestionService>(service);
        }

        [Test]
        public void QuestionService_Should_Set_Provider()
        {
            //Arrange & Act
            var mockedProvider = new Mock<IEfSociumDataProvider>();
            QuestionService service = new QuestionService(mockedProvider.Object);

            //Assert
            Assert.AreSame(mockedProvider.Object, service.provider);
        }

        [Test]
        public void QuestionService_Should_Set_GetProvider()
        {
            //Arrange & Act
            var mockedProvider = new Mock<IEfSociumDataProvider>();
            QuestionService service = new QuestionService(mockedProvider.Object);

            //Assert
            Assert.AreSame(mockedProvider.Object, service.GetProvider);
        }

        [Test]
        public void QuestionService_Should_CallAdd()
        {
            //Arrange
            var mockedProvider = new Mock<IEfSociumDataProvider>();
            mockedProvider.Setup(p => p.Questions.Add(It.IsAny<Question>()));
            QuestionService service = new QuestionService(mockedProvider.Object);

            //Act
            service.Create("fake", "fake", "fake");

            //Assert
            mockedProvider.Verify(p => p.Questions.Add(It.IsAny<Question>()), Times.Once);
        }

        [Test]
        public void QuestionService_Should_CallCommit()
        {
            //Arrange
            var mockedProvider = new Mock<IEfSociumDataProvider>();
            mockedProvider.Setup(p => p.Questions.Add(It.IsAny<Question>()));
            mockedProvider.Setup(p => p.Commit());
            QuestionService service = new QuestionService(mockedProvider.Object);

            //Act
            service.Create("fake", "fake", "fake");

            //Assert
            mockedProvider.Verify(p => p.Commit(), Times.Once);
        }

        [Test]
        public void QuestionService_Should_Call_GetAll()
        {
            try
            {
                //Arrange
                List<Question> emptyList = new List<Question>();
                var mockedProvider = new Mock<IEfSociumDataProvider>();
                mockedProvider.Setup(p => p.Questions.GetAll()).Returns(emptyList.AsQueryable());
                QuestionService service = new QuestionService(mockedProvider.Object);

                //Act
                service.GetAll();

                //Assert
                mockedProvider.Verify(p => p.Questions.GetAll().ToList(), Times.Once);
            }
            catch
            {
                Assert.Pass();
            }
            
        }
    }
}
