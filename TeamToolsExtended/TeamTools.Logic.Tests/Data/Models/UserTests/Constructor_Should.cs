using NUnit.Framework;
using TeamTools.Logic.Data.Models;
using Moq;

namespace TeamTools.Logic.Tests.Data.Models.UserTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ReturnInstanceOfUser_WithSetCorrectProperties()
        {
            string username = "someone@email.bg";
            string email = "someone@email.bg";
            string firstName = "Some";
            string lastName = "Body";
            string gender = "Male";
            var userLogo = new Mock<UserLogo>();

            var user = new User(username, email, firstName, lastName, gender, userLogo.Object);

            Assert.AreEqual(username, user.UserName);
            Assert.AreEqual(email, user.Email);
            Assert.AreEqual(firstName, user.FirstName);
            Assert.AreEqual(lastName, user.LastName);
            Assert.AreEqual(gender, user.Gender);
            Assert.AreEqual(userLogo.Object, user.UserLogo);
            Assert.IsInstanceOf<User>(user);
        }
    }
}
