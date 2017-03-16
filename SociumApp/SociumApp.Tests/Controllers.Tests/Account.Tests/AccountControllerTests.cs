using Moq;
using NUnit.Framework;
using SociumApp.Controllers;
using SociumApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
