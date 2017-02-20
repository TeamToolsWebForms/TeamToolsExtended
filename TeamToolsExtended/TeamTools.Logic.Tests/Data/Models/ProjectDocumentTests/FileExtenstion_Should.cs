using NUnit.Framework;
using TeamTools.Logic.Data.Models;

namespace TeamTools.Logic.Tests.Data.Models.ProjectDocumentTests
{
    [TestFixture]
    public class FileExtenstion_Should
    {
        [TestCase(".doc")]
        [TestCase(".pdf")]
        public void SetFileExtension_Correct(string fileExtension)
        {
            var doc = new ProjectDocument();

            doc.FileExtension = fileExtension;

            Assert.AreEqual(fileExtension, doc.FileExtension);
        }
    }
}
