using NUnit.Framework;
using SociumApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SociumApp.Tests.WebClient.Tests.ViewModels.Tests
{
    [TestFixture]
    public class AccountViewModelsTests
    {
        [TestCase("str1")]
        [TestCase("str2")]
        [TestCase("str3")]
        public void LoginModel_Should_Set_Email(string str)
        {
            //Arrange
            LoginViewModel loginViewModel = new LoginViewModel();

            //Act
            loginViewModel.Email = str;

            //Assert
            Assert.AreEqual(loginViewModel.Email, str);
        }

        [TestCase("str1")]
        [TestCase("str2")]
        [TestCase("str3")]
        public void LoginModel_Should_Set_Password(string str)
        {
            //Arrange
            LoginViewModel loginViewModel = new LoginViewModel();

            //Act
            loginViewModel.Password = str;

            //Assert
            Assert.AreEqual(loginViewModel.Password, str);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void LoginModel_Should_Set_RememberMe(bool val)
        {
            //Arrange
            LoginViewModel loginViewModel = new LoginViewModel();

            //Act
            loginViewModel.RememberMe = val;

            //Assert
            Assert.AreEqual(loginViewModel.RememberMe, val);
        }

        [TestCase("str1")]
        [TestCase("str2")]
        [TestCase("str3")]
        public void RegisterViewModel_Should_Set_Email(string str)
        {
            //Arrange
            RegisterViewModel registerViewModel = new RegisterViewModel();

            //Act
            registerViewModel.Email = str;

            //Assert
            Assert.AreEqual(registerViewModel.Email, str);
        }

        [TestCase("str1")]
        [TestCase("str2")]
        [TestCase("str3")]
        public void RegisterViewModel_Should_Set_Password(string str)
        {
            //Arrange
            RegisterViewModel registerViewModel = new RegisterViewModel();

            //Act
            registerViewModel.Password = str;

            //Assert
            Assert.AreEqual(registerViewModel.Password, str);
        }

        [TestCase("str1")]
        [TestCase("str2")]
        [TestCase("str3")]
        public void RegisterViewModel_Should_Set_ConfirmPassword(string str)
        {
            //Arrange
            RegisterViewModel registerViewModel = new RegisterViewModel();

            //Act
            registerViewModel.ConfirmPassword = str;

            //Assert
            Assert.AreEqual(registerViewModel.ConfirmPassword, str);
        }
    }
}
