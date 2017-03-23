using NUnit.Framework;
using SociumApp.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SociumApp.Tests.WebClient.Tests.ViewModels.Tests
{
    [TestFixture]
    public class IndexAdminViewModelTests
    {
        [Test]
        public void IndexAdminViewModel_Constructor_Should_Initialize_Object()
        {
            //Arrange & Act
            IndexAdminViewModel model = new IndexAdminViewModel();

            //Assert
            Assert.IsInstanceOf<IndexAdminViewModel>(model);
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void IndexAdminViewModel_Should_Set_OptionsCount_Object(int count)
        {
            //Arrange
            IndexAdminViewModel model = new IndexAdminViewModel();

            //Act
            model.OptionsCount = count;

            //Assert
            Assert.AreEqual(count, model.OptionsCount);
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void IndexAdminViewModel_Should_Set_QuestionsCount_Object(int count)
        {
            //Arrange
            IndexAdminViewModel model = new IndexAdminViewModel();

            //Act
            model.QuestionsCount = count;

            //Assert
            Assert.AreEqual(count, model.QuestionsCount);
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void IndexAdminViewModel_Should_Set_VotesCount_Object(int count)
        {
            //Arrange
            IndexAdminViewModel model = new IndexAdminViewModel();

            //Act
            model.VotesCount = count;

            //Assert
            Assert.AreEqual(count, model.VotesCount);
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void IndexAdminViewModel_Should_Set_UsersCount_Object(int count)
        {
            //Arrange
            IndexAdminViewModel model = new IndexAdminViewModel();

            //Act
            model.UsersCount = count;

            //Assert
            Assert.AreEqual(count, model.UsersCount);
        }
    }
}
