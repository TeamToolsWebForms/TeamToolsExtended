using NUnit.Framework;
using TeamTools.Logic.Data.Models;

namespace TeamTools.Logic.Tests.Data.Models.UserLogoTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ReturnInstanceOfUserLogo_WithCorrectSetProperties()
        {
            byte[] content = new byte[] { 1, 123, 124, 12, 34, 54 };

            var userLogo = new UserLogo(content);

            CollectionAssert.AreEqual(content, userLogo.Image);
            Assert.IsInstanceOf<UserLogo>(userLogo);
        }
    }
}
