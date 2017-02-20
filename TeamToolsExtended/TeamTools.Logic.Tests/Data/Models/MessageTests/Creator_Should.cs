using NUnit.Framework;
using TeamTools.Logic.Data.Models;

namespace TeamTools.Logic.Tests.Data.Models.MessageTests
{
    [TestFixture]
    public class Creator_Should
    {
        [TestCase("Someone")]
        [TestCase("Somename")]
        public void SetCreator_Correct(string creator)
        {
            var message = new Message();

            message.Creator = creator;

            Assert.AreEqual(creator, message.Creator);
        }
    }
}
