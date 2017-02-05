using NUnit.Framework;
using TeamTools.Logic.Data.Models;

namespace TeamTools.Logic.Tests.Data.Models.NoteTests
{
    [TestFixture]
    public class IsDeleted_Should
    {
        [TestCase(true)]
        [TestCase(false)]
        public void SetIsDeleted_Correct(bool isDeleted)
        {
            var note = new Note();

            note.IsDeleted = isDeleted;

            Assert.AreEqual(isDeleted, note.IsDeleted);
        }
    }
}
