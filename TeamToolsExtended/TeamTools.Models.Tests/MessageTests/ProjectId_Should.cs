using NUnit.Framework;

namespace TeamTools.Models.Tests.MessageTests
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
