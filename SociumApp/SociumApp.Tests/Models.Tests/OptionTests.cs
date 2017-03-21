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
    public class OptionTests
    {
        [Test]
        public void Option_Constructor_Should_Return_Object()
        {
            //Arrange & Act
            Option option = new Option();

            //Assert
            Assert.IsInstanceOf<Option>(option);
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void Option_Should_Correct_Set_Id(int id)
        {
            //Arrange
            Option option = new Option();

            //Act
            option.Id = id;

            //Assert
            Assert.AreEqual(id, option.Id);
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void Option_Should_Correct_Set_QuestionId(int id)
        {
            //Arrange
            Option option = new Option();

            //Act
            option.QuestionId = id;

            //Assert
            Assert.AreEqual(id, option.QuestionId);
        }

        [TestCase("abc1")]
        [TestCase("abc2")]
        [TestCase("mvc3")]
        public void Option_Should_Correct_Set_OwnerId(string id)
        {
            //Arrange
            Option option = new Option();

            //Act
            option.OwnerId = id;

            //Assert
            Assert.AreEqual(id, option.OwnerId);
        }

        [Test]
        public void Option_Should_Correct_Set_Owner()
        {
            //Arrange
            ApplicationUser user = new ApplicationUser();
            Option option = new Option();

            //Act
            option.Owner = user;

            //Assert
            Assert.AreSame(user, option.Owner);
        }

        [Test]
        public void Option_Should_Correct_Set_Question()
        {
            //Arrange
            Question question = new Question();
            Option option = new Option();

            //Act
            option.Question = question;

            //Assert
            Assert.AreSame(question, option.Question);
        }

        [TestCase("desc1")]
        [TestCase("desc2")]
        [TestCase("desc3")]
        public void Option_Should_Correct_Set_Description(string description)
        {
            //Arrange
            Option option = new Option();

            //Act
            option.Description = description;

            //Assert
            Assert.AreEqual(description, option.Description);
        }

        public void Option_Should_Correct_Add_Votes()
        {
            //Arrange
            Option option = new Option();
            Vote vote = new Vote();

            //Act
            option.Votes.Add(vote);

            //Assert
            Assert.IsTrue(option.Votes.Count > 0);
        }
    }
}
