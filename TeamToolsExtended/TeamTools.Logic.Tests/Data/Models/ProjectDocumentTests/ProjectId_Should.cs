using NUnit.Framework;
using TeamTools.Logic.Data.Models;

namespace TeamTools.Logic.Tests.Data.Models.ProjectDocumentTests
{
    [TestFixture]
    public class ProjectId_Should
    {
        [TestCase(1)]
        [TestCase(211)]
        public void SetProjectId_Correct(int id)
        {
            var doc = new ProjectDocument();

            doc.ProjectId = id;

            Assert.AreEqual(id, doc.ProjectId);
        }
    }
}
