using Moq;
using NUnit.Framework;
using SociumApp.Data;
using SociumApp.Data.Contracts;
using SociumApp.Models;
using SociumApp.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SociumApp.Tests.Data.Tests.Repositories.Tests
{
    public class FakeClass : IEfModel
    {
        public int Id
        {
            get
            {
                return 1;
            }

            set
            {
               
            }
        }

        public static IEnumerable<FakeClass> GetCollection()
        {
            return new List<FakeClass>()
            {
                new FakeClass(),
                new FakeClass(),
                new FakeClass()
            };
        }
    }

    [TestFixture]
    public class EfRepositoryTests
    {
        [Test]
        public void EfRepo_Constructor_Should_Return_Object()
        {
            //Arrange & Act
            var mockedDbContext = new Mock<ISociumDbContext>();
            EfRepository<FakeClass> repo = new EfRepository<FakeClass>(mockedDbContext.Object);

            //Assert
            Assert.IsInstanceOf<EfRepository<FakeClass>>(repo);
        }

        [Test]
        public void EfRepo_Should_Call_GetDbSet()
        {
            //Arrange & Act
            FakeClass fake = new FakeClass();
            var mockedDbSet = new Mock<IDbSet<FakeClass>>();
            mockedDbSet.Setup(x => x.Add(fake)).Verifiable();
            var mockedDbContext = new Mock<ISociumDbContext>();
            mockedDbContext.Setup(c => c.GetDbSet<FakeClass>()).Returns(mockedDbSet.Object);
            EfRepository<FakeClass> repo = new EfRepository<FakeClass>(mockedDbContext.Object);

            //Assert
            mockedDbContext.Verify(c => c.GetDbSet<FakeClass>(), Times.Once);
        }

        [Test]
        public void EfRepo_Should_Return_Querable_When_GetAll()
        {
            //Arrange
            var mockedCollection = FakeClass.GetCollection();
            Expression<Func<FakeClass, bool>> expectedExpression = x => x.Id > 0;
            IEnumerable<FakeClass> expectedResult = mockedCollection.Where(expectedExpression.Compile()).ToList();
            var queryable = mockedCollection.AsQueryable();
            var mockedDbSet = new Mock<IDbSet<FakeClass>>();
            mockedDbSet.As<IQueryable<FakeClass>>().Setup(m => m.Provider).Returns(queryable.Provider);
            mockedDbSet.As<IQueryable<FakeClass>>().Setup(m => m.Expression).Returns(queryable.Expression);
            mockedDbSet.As<IQueryable<FakeClass>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            mockedDbSet.As<IQueryable<FakeClass>>().Setup(m => m.GetEnumerator()).Returns(queryable.GetEnumerator());
            var mockedDbContext = new Mock<ISociumDbContext>();
            mockedDbContext.Setup(c => c.GetDbSet<FakeClass>()).Returns(mockedDbSet.Object);
            EfRepository<FakeClass> repo = new EfRepository<FakeClass>(mockedDbContext.Object);
            
            //Act
            var res = repo.GetAll();

            //Assert
            CollectionAssert.AreEquivalent(expectedResult, res.ToList());
        }

        [Test]
        public void EfRepo_Call_Find_When_Call_GetBy()
        {
            //Arrange
            object id = 1;
            FakeClass fake = new FakeClass();
            var mockedDbSet = new Mock<IDbSet<FakeClass>>();
            mockedDbSet.Setup(x => x.Find(It.IsAny<object>())).Verifiable();
            var mockedDbContext = new Mock<ISociumDbContext>();
            mockedDbContext.Setup(c => c.GetDbSet<FakeClass>()).Returns(mockedDbSet.Object);
            EfRepository<FakeClass> repo = new EfRepository<FakeClass>(mockedDbContext.Object);

            //Act
            repo.GetBy(id);

            //Assert
            mockedDbSet.Verify(s => s.Find(It.IsAny<object>()), Times.Once);
        }

        [Test]
        public void EfRepo_Call_Find_Should_Return_Correct()
        {
            //Arrange
            object id = 1;
            FakeClass fake = new FakeClass();
            var mockedDbSet = new Mock<IDbSet<FakeClass>>();
            mockedDbSet.Setup(x => x.Find(It.IsAny<object>())).Returns(fake);
            var mockedDbContext = new Mock<ISociumDbContext>();
            mockedDbContext.Setup(c => c.GetDbSet<FakeClass>()).Returns(mockedDbSet.Object);
            EfRepository<FakeClass> repo = new EfRepository<FakeClass>(mockedDbContext.Object);

            //Act
            var res = repo.GetBy(id);

            //Assert
            Assert.AreSame(fake, res);
        }

        [Test]
        public void EfRepo_Call_Remove_Should_Call_Remove()
        {
            //Arrange
            FakeClass fake = new FakeClass();
            var mockedDbSet = new Mock<IDbSet<FakeClass>>();
            mockedDbSet.Setup(x => x.Remove(It.IsAny<FakeClass>())).Verifiable();
            var mockedDbContext = new Mock<ISociumDbContext>();
            mockedDbContext.Setup(c => c.GetDbSet<FakeClass>()).Returns(mockedDbSet.Object);
            EfRepository<FakeClass> repo = new EfRepository<FakeClass>(mockedDbContext.Object);

            //Act
            repo.Remove(fake);

            //Assert
            mockedDbSet.Verify(x => x.Remove(It.IsAny<FakeClass>()), Times.Once);
        }
    }
}
