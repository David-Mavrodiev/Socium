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
    public class QuestionTests
    {
        [Test]
        public void Question_Should_Successfully_Initialize_Object()
        {
            //Arrange & Act
            Question question = new Question();

            //Assert
            Assert.IsInstanceOf<Question>(question);
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void Question_Should_Correct_Set_Id(int id)
        {
            //Arrange
            Question question = new Question();

            //Act
            question.Id = id;

            //Assert
            Assert.AreEqual(id, question.Id);
        }

        [TestCase("tit1")]
        [TestCase("tit2")]
        [TestCase("tit3")]
        public void Question_Should_Correct_Set_Title(string title)
        {
            //Arrange
            Question question = new Question();

            //Act
            question.Title = title;

            //Assert
            Assert.AreEqual(title, question.Title);
        }

        [Test]
        public void Question_Should_Correct_Add_Option()
        {
            //Arrange
            Question question = new Question();
            Option option = new Option();

            //Act
            question.Options.Add(option);

            //Assert
            Assert.IsTrue(question.Options.Count > 0);
        }
    }
}
