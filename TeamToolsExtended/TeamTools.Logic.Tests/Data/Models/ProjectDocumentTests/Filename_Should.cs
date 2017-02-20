using NUnit.Framework;
using TeamTools.Logic.Data.Models;

namespace TeamTools.Logic.Tests.Data.Models.ProjectDocumentTests
{
    [TestFixture]
    public class Filename_Should
    {
        [TestCase("somename")]
        [TestCase("justnameagain")]
        public void SetFilename_Correct(string filename)
        {
            var doc = new ProjectDocument();

            doc.FileName = filename;

            Assert.AreEqual(filename, doc.FileName);
        }
    }
}
