using NUnit.Framework;
using TeamTools.Logic.Data.Models;

namespace TeamTools.Logic.Tests.Data.Models.MessageTests
{
    [TestFixture]
    public class Id_Should
    {
        [TestCase(1)]
        [TestCase(2)]
        public void SetId(int id)
        {
            var message = new Message();

            message.Id = id;

            Assert.AreEqual(id, message.Id);
        }
    }
}
