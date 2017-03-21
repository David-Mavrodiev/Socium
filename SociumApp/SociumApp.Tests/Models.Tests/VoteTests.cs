using NUnit.Framework;
using SociumApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SociumApp.Tests.Models.Tests
{
    [TestFixture]
    public class VoteTests
    {
        [Test]
        public void Vote_Constructor_Should_Successfully_Initialize_Object()
        {
            //Arrange & Act
            Vote vote = new Vote();

            //Assert
            Assert.IsInstanceOf<Vote>(vote);
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void Vote_Should_Correct_Set_Id(int id)
        {
            //Arrange
            Vote vote = new Vote();

            //Act
            vote.Id = id;

            //Assert
            Assert.AreEqual(id, vote.Id);
        }

        [TestCase("abc1")]
        [TestCase("abc2")]
        [TestCase("mvc3")]
        public void Vote_Should_Correct_Set_OwnerId(string id)
        {
            //Arrange
            Vote vote = new Vote();

            //Act
            vote.OwnerId = id;

            //Assert
            Assert.AreEqual(id, vote.OwnerId);
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void Vote_Should_Correct_Set_QuestionId(int id)
        {
            //Arrange
            Vote vote = new Vote();

            //Act
            vote.QuestionId = id;

            //Assert
            Assert.AreEqual(id, vote.QuestionId);
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void Vote_Should_Correct_Set_OptionId(int id)
        {
            //Arrange
            Vote vote = new Vote();

            //Act
            vote.OptionId = id;

            //Assert
            Assert.AreEqual(id, vote.OptionId);
        }

        [Test]
        public void Vote__Should_Correct_Set_Owner()
        {
            //Arrange
            Vote vote = new Vote();
            ApplicationUser user = new ApplicationUser();

            //Act
            vote.Owner = user;

            //Assert
            Assert.AreSame(user, vote.Owner);
        }

        [Test]
        public void Vote__Should_Correct_Set_Option()
        {
            //Arrange
            Vote vote = new Vote();
            Option option = new Option();

            //Act
            vote.Option = option;

            //Assert
            Assert.AreSame(option, vote.Option);
        }

        [Test]
        public void Vote_Should_Correct_Set_Question()
        {
            //Arrange
            Vote vote = new Vote();
            Question question = new Question();

            //Act
            vote.Question = question;

            //Assert
            Assert.AreSame(question, vote.Question);
        }
    }
}
