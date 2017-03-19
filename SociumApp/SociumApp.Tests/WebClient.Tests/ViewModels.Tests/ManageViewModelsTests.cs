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
    public class ManageViewModelsTests
    {
        [Test]
        public void IndexViewModel_Constructor_Should_Return_Object()
        {
            //Arrange & Act
            IndexViewModel indexViewModel = new IndexViewModel();

            //Assert
            Assert.IsInstanceOf<IndexViewModel>(indexViewModel);
        }

        [TestCase("str1")]
        [TestCase("str2")]
        [TestCase("str3")]
        public void IndexViewModel_Should_Set_Username(string str)
        {
            //Arrange
            IndexViewModel indexViewModel = new IndexViewModel();

            //Act
            indexViewModel.Username = str;

            //Assert
            Assert.AreEqual(str, indexViewModel.Username);
        }
    }
}
