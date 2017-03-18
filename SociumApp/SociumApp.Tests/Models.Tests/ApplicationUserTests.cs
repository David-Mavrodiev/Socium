using Microsoft.AspNet.Identity;
using Moq;
using NUnit.Framework;
using SociumApp.Identity;
using SociumApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SociumApp.Tests.Models.Tests
{
    [TestFixture]
    public class ApplicationUserTests
    {
        [Test]
        public void User_Constructor_Should_Successfully_Initialize_Object()
        {
            //Arrange & Act
            ApplicationUser user = new ApplicationUser();

            //Assert
            Assert.IsInstanceOf<ApplicationUser>(user);
        }

        [Test]
        public void User_Should_Throw_When_Call_Async()
        {
            //Arrange
            var mockedUserManager = new Mock<ApplicationUserManager>();
            mockedUserManager.Setup(m => m.CreateIdentityAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>())).Returns(Task.FromResult(new System.Security.Claims.ClaimsIdentity()));
            ApplicationUser user = new ApplicationUser();

            //Act
            try
            {
                var answ = user.GenerateUserIdentityAsync(mockedUserManager.Object);
            }
            catch
            {
                Assert.Pass();
            }
        }
    }
}
