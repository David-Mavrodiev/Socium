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
        public void QuestionService_Create_Should_Call_Repo_Add()
        {
            //Arrange
            Question question = new Question();
            var mockedRepo = new Mock<IEfRepository<Question>>();
            mockedRepo.Setup(r => r.Add(It.IsAny<Question>()));
            var mockedProvider = new Mock<IEfSociumDataProvider>();
            mockedProvider.Setup(p => p.Commit());
            mockedProvider.Setup(p => p.Questions).Returns(mockedRepo.Object);
            mockedProvider.Setup(p => p.FindQuestionByTitle(It.IsAny<string>())).Returns(question);
            QuestionService service = new QuestionService(mockedProvider.Object);

            //Act
            service.Create("test", "test", "test");

            //Assert
            mockedRepo.Verify(r => r.Add(It.IsAny<Question>()), Times.Once);
        }

        [Test]
        public void QuestionService_Create_Should_Call_Provider_Commit()
        {
            //Arrange
            Question question = new Question();
            var mockedRepo = new Mock<IEfRepository<Question>>();
            mockedRepo.Setup(r => r.Add(It.IsAny<Question>()));
            var mockedProvider = new Mock<IEfSociumDataProvider>();
            mockedProvider.Setup(p => p.Commit());
            mockedProvider.Setup(p => p.Questions).Returns(mockedRepo.Object);
            mockedProvider.Setup(p => p.FindQuestionByTitle(It.IsAny<string>())).Returns(question);
            QuestionService service = new QuestionService(mockedProvider.Object);

            //Act
            service.Create("test", "test", "test");

            //Assert
            mockedProvider.Verify(p => p.Commit(), Times.AtLeast(2));
        }

        [Test]
        public void QuestionService_Create_Should_Add_Option_To_Question()
        {
            //Arrange
            Question question = new Question();
            var mockedRepo = new Mock<IEfRepository<Question>>();
            mockedRepo.Setup(r => r.Add(It.IsAny<Question>()));
            var mockedProvider = new Mock<IEfSociumDataProvider>();
            mockedProvider.Setup(p => p.Commit());
            mockedProvider.Setup(p => p.Questions).Returns(mockedRepo.Object);
            mockedProvider.Setup(p => p.FindQuestionByTitle(It.IsAny<string>())).Returns(question);
            QuestionService service = new QuestionService(mockedProvider.Object);

            //Act
            service.Create("test", "test", "test");

            //Assert
            Assert.IsTrue(question.Options.Count > 0);
        }

        [Test]
        public void QuestionService_GetById_Should_Call_Provider_Question_GetById()
        {
            //Arrange
            Question question = new Question();
            var mockedRepo = new Mock<IEfRepository<Question>>();
            mockedRepo.Setup(r => r.GetBy(It.IsAny<object>())).Returns(question);
            var mockedProvider = new Mock<IEfSociumDataProvider>();
            mockedProvider.Setup(p => p.Questions).Returns(mockedRepo.Object);
            QuestionService service = new QuestionService(mockedProvider.Object);

            //Act
            var result = service.GetById(1);

            //Assert
            Assert.AreEqual(question, result);
        }

        [Test]
        public void QuestionService_AddOptionToQuestion_Should_Call_Provider_Commit()
        {
            //Arrange
            Question question = new Question();
            var mockedRepo = new Mock<IEfRepository<Question>>();
            mockedRepo.Setup(r => r.GetBy(It.IsAny<object>())).Returns(question);
            var mockedProvider = new Mock<IEfSociumDataProvider>();
            mockedProvider.Setup(p => p.Commit());
            mockedProvider.Setup(p => p.Questions).Returns(mockedRepo.Object);
            QuestionService service = new QuestionService(mockedProvider.Object);

            //Act
            service.AddOptionToQuestion(0, "test", "test");

            //Assert
            mockedProvider.Verify(p => p.Commit(), Times.Once);
        }

        [Test]
        public void QuestionService_AddOptionToQuestion_Should_Add_Option()
        {
            //Arrange
            Question question = new Question();
            var mockedRepo = new Mock<IEfRepository<Question>>();
            mockedRepo.Setup(r => r.GetBy(It.IsAny<object>())).Returns(question);
            var mockedProvider = new Mock<IEfSociumDataProvider>();
            mockedProvider.Setup(p => p.Commit());
            mockedProvider.Setup(p => p.Questions).Returns(mockedRepo.Object);
            QuestionService service = new QuestionService(mockedProvider.Object);

            //Act
            service.AddOptionToQuestion(0, "test", "test");

            //Assert
            Assert.IsTrue(question.Options.Count > 0);
        }

        [Test]
        public void QuestionService_AddVoteToOption_Call_Provider_Commit()
        {
            //Arrange
            Option option = new Option();
            var mockedRepo = new Mock<IEfRepository<Option>>();
            mockedRepo.Setup(r => r.GetBy(It.IsAny<object>())).Returns(option);
            var mockedProvider = new Mock<IEfSociumDataProvider>();
            mockedProvider.Setup(p => p.Commit());
            mockedProvider.Setup(p => p.Options).Returns(mockedRepo.Object);
            QuestionService service = new QuestionService(mockedProvider.Object);

            //Act
            service.AddVoteToOption(0, 0, "test");

            //Assert
            mockedProvider.Verify(p => p.Commit(), Times.Once);
        }

        [Test]
        public void QuestionService_AddVoteToOption_Add_Vote_To_Option()
        {
            //Arrange
            Option option = new Option();
            var mockedRepo = new Mock<IEfRepository<Option>>();
            mockedRepo.Setup(r => r.GetBy(It.IsAny<object>())).Returns(option);
            var mockedProvider = new Mock<IEfSociumDataProvider>();
            mockedProvider.Setup(p => p.Commit());
            mockedProvider.Setup(p => p.Options).Returns(mockedRepo.Object);
            QuestionService service = new QuestionService(mockedProvider.Object);

            //Act
            service.AddVoteToOption(0, 0, "test");

            //Assert
            Assert.IsTrue(option.Votes.Count > 0);
        }

        [Test]
        public void QuestionService_GetAll_Should_Work()
        {
            //Arrange
            List<Question> questions = new List<Question>();
            var mockedRepo = new Mock<IEfRepository<Question>>();
            mockedRepo.Setup(r => r.GetAll()).Returns(questions.AsQueryable());
            var mockedProvider = new Mock<IEfSociumDataProvider>();
            mockedProvider.Setup(p => p.Questions).Returns(mockedRepo.Object);
            QuestionService service = new QuestionService(mockedProvider.Object);

            //Act
            var result = service.GetAll();

            //Assert
            Assert.AreEqual(questions, result);
        }
    }
}
