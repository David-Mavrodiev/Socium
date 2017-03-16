using NUnit.Framework;
using SociumApp.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SociumApp.Tests.Controllers.Tests.Home.Tests
{
    [TestFixture]
    public class HomeControllerTests
    {
        [Test]
        public void Home_Index_Action_Should_Return_View()
        {
            //Arrange
            HomeController controller = new HomeController();

            //Act
            ViewResult result = controller.Index() as ViewResult;

            //Assert
            Assert.IsInstanceOf<ViewResult>(result);
        }
    }
}
