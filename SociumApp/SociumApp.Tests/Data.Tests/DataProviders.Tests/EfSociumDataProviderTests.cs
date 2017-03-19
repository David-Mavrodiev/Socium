using Moq;
using NUnit.Framework;
using SociumApp.Data;
using SociumApp.Data.Contracts;
using SociumApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SociumApp.Tests.Data.Tests.DataProviders.Tests
{
    [TestFixture]
    public class EfSociumDataProviderTests
    {
        [Test]
        public void EfDataProvider_Constructor_Should_Return_Object()
        {
            //Arrange & Act
            var mockedDbContext = new Mock<IEfSociumDbContext>();
            EfSociumDataProvider provider = new EfSociumDataProvider(mockedDbContext.Object);

            //Assert
            Assert.IsInstanceOf<EfSociumDataProvider>(provider);
        }

        [Test]
        public void EfDataProvider_Get_Questions()
        {
            //Arrange
            var mockedDbContext = new Mock<IEfSociumDbContext>();
            EfSociumDataProvider provider = new EfSociumDataProvider(mockedDbContext.Object);

            //Act
            var res = provider.Questions;

            //Assert
            Assert.IsInstanceOf<IEfRepository<Question>>(res);
        }

        [Test]
        public void EfDataProvider_Get_Options()
        {
            //Arrange
            var mockedDbContext = new Mock<IEfSociumDbContext>();
            EfSociumDataProvider provider = new EfSociumDataProvider(mockedDbContext.Object);

            //Act
            var res = provider.Options;

            //Assert
            Assert.IsInstanceOf<IEfRepository<Option>>(res);
        }

        [Test]
        public void EfDataProvider_Get_Users()
        {
            //Arrange
            var mockedDbContext = new Mock<IEfSociumDbContext>();
            EfSociumDataProvider provider = new EfSociumDataProvider(mockedDbContext.Object);

            //Act
            var res = provider.Users;

            //Assert
            Assert.IsInstanceOf<IEfRepository<ApplicationUser>>(res);
        }

        [Test]
        public void EfDataProvider_Get_Votes()
        {
            //Arrange
            var mockedDbContext = new Mock<IEfSociumDbContext>();
            EfSociumDataProvider provider = new EfSociumDataProvider(mockedDbContext.Object);

            //Act
            var res = provider.Votes;

            //Assert
            Assert.IsInstanceOf<IEfRepository<Vote>>(res);
        }

        [Test]
        public void EfDataProvider_Should_Call_DbContext_SaveChanges_When_Call_Commit()
        {
            //Arrange
            var mockedDbContext = new Mock<IEfSociumDbContext>();
            mockedDbContext.Setup(c => c.SaveChanges());
            EfSociumDataProvider provider = new EfSociumDataProvider(mockedDbContext.Object);

            //Act
            provider.Commit();

            //Assert
            mockedDbContext.Verify(c => c.SaveChanges(), Times.Once);
        }
    }
}
