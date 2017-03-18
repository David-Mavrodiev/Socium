using NUnit.Framework;
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
    }
}
