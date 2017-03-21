using NUnit.Framework;
using SociumApp.Areas.Profile.Models;
using SociumApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SociumApp.Tests.WebClient.Tests.ViewModels.Tests
{
    [TestFixture]
    public class IndexViewModelTests
    {
        [Test]
        public void IndexViewModel_Constructor_Should_Initialize_Object()
        {
            //Arrange & Act
            IndexViewModel model = new IndexViewModel();

            //Assert
            Assert.IsInstanceOf<IndexViewModel>(model);
        }

        [TestCase("pesho")]
        [TestCase("gosho")]
        [TestCase("petar")]
        public void IndexViewModel_Constructor_Should_Set_Username(string username)
        {
            //Arrange
            IndexViewModel model = new IndexViewModel();

            //Act
            model.Username = username;

            //Assert
            Assert.AreEqual(username, model.Username);
        }

        [Test]
        public void IndexViewModel_Should_Set_MyVotes()
        {
            //Arrange
            IndexViewModel model = new IndexViewModel();
            List<Vote> myVotes = new List<Vote>();

            //Act
            model.MyVotes = myVotes;

            //Assert
            Assert.AreSame(myVotes, model.MyVotes);
        }

        [Test]
        public void IndexViewModel_Should_Set_MyQuestions()
        {
            //Arrange
            IndexViewModel model = new IndexViewModel();
            List<Question> myQuestions = new List<Question>();

            //Act
            model.MyQuestions = myQuestions;

            //Assert
            Assert.AreSame(myQuestions, model.MyQuestions);
        }
    }
}
