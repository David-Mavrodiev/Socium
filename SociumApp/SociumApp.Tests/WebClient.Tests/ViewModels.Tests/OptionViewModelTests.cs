using NUnit.Framework;
using SociumApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SociumApp.Tests.WebClient.Tests.ViewModels.Tests
{
    [TestFixture]
    public class OptionViewModelTests
    {
        [Test]
        public void OptionViewModel_Constructor_Should_Initialize_Object()
        {
            //Arrange & Act
            OptionViewModel model = new OptionViewModel();

            //Assert
            Assert.IsInstanceOf<OptionViewModel>(model);
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void OptionViewModel_Should_Set_Id(int id)
        {
            //Arrange
            OptionViewModel model = new OptionViewModel();

            //Act
            model.Id = id;

            //Assert
            Assert.AreEqual(id, model.Id);
        }

        [TestCase("desc1")]
        [TestCase("desc2")]
        [TestCase("desc3")]
        public void OptionViewModel_Should_Set_Description(string description)
        {
            //Arrange
            OptionViewModel model = new OptionViewModel();

            //Act
            model.Description = description;

            //Assert
            Assert.AreEqual(description, model.Description);
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void OptionViewModel_Should_Set_VotesCount(int count)
        {
            //Arrange
            OptionViewModel model = new OptionViewModel();

            //Act
            model.VotesCount = count;

            //Assert
            Assert.AreEqual(count, model.VotesCount);
        }

        [Test]
        public void OptionViewModel_Should_Set_Question()
        {
            //Arrange
            Question question = new Question();
            OptionViewModel model = new OptionViewModel();

            //Act
            model.Question = question;

            //Assert
            Assert.AreEqual(question, model.Question);
        }

        [Test]
        public void OptionViewModel_Should_Set_Option()
        {
            //Arrange
            Option option = new Option();
            OptionViewModel model = new OptionViewModel();

            //Act
            model.Option = option;

            //Assert
            Assert.AreEqual(option, model.Option);
        }
    }
}
