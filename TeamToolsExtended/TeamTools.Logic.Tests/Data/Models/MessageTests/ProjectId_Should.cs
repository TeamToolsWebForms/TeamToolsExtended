using NUnit.Framework;
using TeamTools.Logic.Data.Models;

namespace TeamTools.Logic.Tests.Data.Models.MessageTests
{
    [TestFixture]
    public class ProjectId_Should
    {
        [TestCase(1)]
        [TestCase(2)]
        public void SetProjectId(int id)
        {
            var message = new Message();

            message.ProjectId = id;

            Assert.AreEqual(id, message.ProjectId);
        }
    }
}
