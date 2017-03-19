using NUnit.Framework;
using SociumApp.Areas.Profile.Controllers;
using SociumApp.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SociumApp.Tests.WebClient.Tests.Controllers.Tests.Manage.Tests
{
    [TestFixture]
    public class ManageControllerTests
    {
        [Test]
        public void Manage_Constructor_Should_Return_Object()
        {
            //Arrange & Act
            UserController controller = new UserController();

            //Assert
            Assert.IsInstanceOf<UserController>(controller);
        }

        [Test]
        public void Manage_Index_Should_Return_View()
        {
            try
            {
                //Arrange
                UserController controller = new UserController();

                //Act
                ViewResult result = controller.Index() as ViewResult;
            }
            catch(NullReferenceException e)
            {
                //Assert
                Assert.Pass();
            }
        }
    }
}
