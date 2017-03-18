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
    public class VoteTests
    {
        [Test]
        public void Vote_Constructor_Should_Successfully_Initialize_Object()
        {
            //Arrange & Act
            Vote vote = new Vote();

            //Assert
            Assert.IsInstanceOf<Vote>(vote);
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void Vote_Should_Correct_Set_Id(int id)
        {
            //Arrange
            Vote vote = new Vote();

            //Act
            vote.Id = id;

            //Assert
            Assert.AreEqual(id, vote.Id);
        }

        [Test]
        public void Vote_Should_Correct_Add_LikedUser()
        {
            //Arrange
            Vote vote = new Vote();
            ApplicationUser user = new ApplicationUser();

            //Act
            vote.LikedUsers.Add(user);

            //Assert
            Assert.IsTrue(vote.LikedUsers.Count > 0);
        }

        [Test]
        public void Vote__Should_Correct_Set_Owner()
        {
            //Arrange
            Vote vote = new Vote();
            ApplicationUser user = new ApplicationUser();

            //Act
            vote.Owner = user;

            //Assert
            Assert.AreSame(user, vote.Owner);
        }
    }
}
