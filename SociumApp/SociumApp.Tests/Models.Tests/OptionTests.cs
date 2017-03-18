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
