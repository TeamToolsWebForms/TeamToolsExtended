using NUnit.Framework;
using TeamTools.Logic.Data.Models;

namespace TeamTools.Logic.Tests.Data.Models.ProjectDocumentTests
{
    [TestFixture]
    public class FileContent_Should
    {
        [TestCase(new byte[] { 12, 43, 43, 112, 122, 98 })]
        [TestCase(new byte[] { 1, 43, 55, 23, 76, 123, 33, 123, 46, 88 })]
        public void SetFileContent_Correct(byte[] content)
        {
            var doc = new ProjectDocument();

            doc.FileContent = content;

            CollectionAssert.AreEqual(content, doc.FileContent);
        }
    }
}
