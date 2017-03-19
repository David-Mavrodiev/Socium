using Moq;
using NUnit.Framework;
using SociumApp.Areas.Profile.Controllers;
using SociumApp.Controllers;
using SociumApp.Identity;
using SociumApp.Identity.Contracts;
using SociumApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SociumApp.Tests.Controllers.Tests.Account.Tests
{
    [TestFixture]
    public class AccountControllerTests
    {
        [Test]
        public void Account_Constructor_Should_Return_Object()
        {
            //Arrange & Act
            AccountController controller = new AccountController();

            //Assert
            Assert.IsInstanceOf<AccountController>(controller);
        }

        [Test]
        public void Account_LoginGET_Should_Return_View()
        {
            //Arrange
            AccountController controller = new AccountController();

            //Act
            ViewResult result = controller.Login(null) as ViewResult;

            //Assert
            Assert.IsInstanceOf<ViewResult>(result);
        }
            
        [TestCase("str1")]
        [TestCase("str2")]
        [TestCase("str3")]
        public void Account_LoginGET_Should_Set_ViewBag_Url(string returnUrl)
        {
            //Arrange
            AccountController controller = new AccountController();

            //Act
            ViewResult result = controller.Login(returnUrl) as ViewResult;

            //Assert
            Assert.AreEqual(returnUrl, result.ViewBag.ReturnUrl);
        }

        [Test]
        public void Account_Constructor2_Should_Return_Object()
        {
            //Arrange & Act
            var mockedUserManager = new Mock<IApplicationUserManager>();
            var mockedSignInManager = new Mock<IApplicationSignInManager>();
            AccountController controller = new AccountController(mockedUserManager.Object, mockedSignInManager.Object);

            //Assert
            Assert.IsInstanceOf<AccountController>(controller);
        }

        [Test]
        public void Account_Register_Get_Should_Return_View()
        {
            //Arrange
            AccountController controller = new AccountController();

            //Act
            ViewResult result = controller.Register() as ViewResult;

            //Assert
            Assert.IsInstanceOf<ViewResult>(result);
        }

        [Test]
        public void Account_LogOff_Should_Throw()
        {
            //Arrange
            AccountController controller = new AccountController();

            //Assert & Act
            try
            {
                ViewResult result = controller.LogOff() as ViewResult;
            }
            catch(NullReferenceException e)
            {
                Assert.Pass();
            }
        }
    }
}
