using NUnit.Framework;
using TeamTools.Logic.Data.Models;

namespace TeamTools.Logic.Tests.Data.Models.ProjectDocumentTests
{
    [TestFixture]
    public class Id_Should
    {
        [TestCase(21)]
        [TestCase(12312)]
        public void SetId_Correct(int id)
        {
            var doc = new ProjectDocument();

            doc.Id = id;

            Assert.AreEqual(id, doc.Id);
        }
    }
}
