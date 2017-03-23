using Moq;
using NUnit.Framework;
using SociumApp.Helpers;
using SociumApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SociumApp.Tests.WebClient.Tests.Helpers.Tests
{
    [TestFixture]
    public class MapperHelperTests
    {
        [Test]
        public void MapperHelper_Constructor_Should_Initialize_Object()
        {
            //Arrange & Act
            MapperHelper helper = new MapperHelper();

            //Assert
            Assert.IsInstanceOf<MapperHelper>(helper);
        }

        [Test]
        public void MapperHelper_MapQuestionToViewModel_Should_Work()
        {
            //Arrange
            ApplicationUser user = new ApplicationUser()
            {
                UserName = "Pesho"
            };
            Question question = new Question()
            {
                Id = 0,
                Title = "test",
                OwnerId = "1",
                Owner = user
            };
            MapperHelper helper = new MapperHelper();

            //Act
            var model = helper.MapQuestionToViewModel(question);

            //Assert
            Assert.AreEqual(question.Title, model.Title);
            Assert.AreEqual(question.Options.Count, model.Options.Count);
            Assert.AreEqual(question.Id, model.Id);
            Assert.AreEqual(question.Owner.UserName, model.OwnerUsername);
        }

        [Test]
        public void MapperHelper_MapQuestionsToViewModel_Should_Work()
        {
            //Arrange
            ApplicationUser user = new ApplicationUser()
            {
                UserName = "Pesho"
            };
            Question question = new Question()
            {
                Id = 0,
                Title = "test",
                OwnerId = "1",
                Owner = user
            };

            List<Question> questions = new List<Question>()
            {
                question
            };

            MapperHelper helper = new MapperHelper();

            //Act
            var model = helper.MapQuestionsToViewModel(questions);

            //Assert
            Assert.AreEqual(question.Title, model[0].Title);
            Assert.AreEqual(question.Options.Count, model[0].Options.Count);
            Assert.AreEqual(question.Id, model[0].Id);
            Assert.AreEqual(question.Owner.UserName, model[0].OwnerUsername);
        }
    }
}
