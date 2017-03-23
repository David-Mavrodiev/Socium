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
    public class QuestionViewModelTests
    {
        [Test]
        public void QuestionViewModel_Constructor_Should_Initialize_Object()
        {
            //Arrange & Act
            QuestionViewModel model = new QuestionViewModel();

            //Assert
            Assert.IsInstanceOf<QuestionViewModel>(model);
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void QuestionViewModel_Should_Set_Id(int id)
        {
            //Arrange
            QuestionViewModel model = new QuestionViewModel();

            //Act
            model.Id = id;

            //Assert
            Assert.AreEqual(id, model.Id);
        }

        [TestCase("Pesho")]
        [TestCase("Gosho")]
        [TestCase("Stamat")]
        public void QuestionViewModel_Should_Set_OwnerUsername(string ownerUsername)
        {
            //Arrange
            QuestionViewModel model = new QuestionViewModel();

            //Act
            model.OwnerUsername = ownerUsername;

            //Assert
            Assert.AreEqual(ownerUsername, model.OwnerUsername);
        }

        [TestCase("title1")]
        [TestCase("title2")]
        [TestCase("title3")]
        public void QuestionViewModel_Should_Set_Title(string title)
        {
            //Arrange
            QuestionViewModel model = new QuestionViewModel();

            //Act
            model.Title = title;

            //Assert
            Assert.AreEqual(title, model.Title);
        }

        [Test]
        public void QuestionViewModel_Should_Set_Options()
        {
            //Arrange
            List<OptionViewModel> options = new List<OptionViewModel>();
            QuestionViewModel model = new QuestionViewModel();

            //Act
            model.Options = options;

            //Assert
            Assert.AreSame(options, model.Options);
        }
    }
}
