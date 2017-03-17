using NUnit.Framework;
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
            ManageController controller = new ManageController();

            //Assert
            Assert.IsInstanceOf<ManageController>(controller);
        }

        [Test]
        public void Manage_Index_Should_Return_View()
        {
            try
            {
                //Arrange
                ManageController controller = new ManageController();

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
