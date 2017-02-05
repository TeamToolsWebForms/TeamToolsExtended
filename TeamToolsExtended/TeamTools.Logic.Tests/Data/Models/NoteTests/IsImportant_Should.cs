using NUnit.Framework;
using TeamTools.Logic.Data.Models;

namespace TeamTools.Logic.Tests.Data.Models.NoteTests
{
    [TestFixture]
    public class IsImportant_Should
    {
        [TestCase(true)]
        [TestCase(false)]
        public void SetIsImportant_Correct(bool isImportant)
        {
            var note = new Note();

            note.IsImportant = isImportant;

            Assert.AreEqual(isImportant, note.IsImportant);
        }
    }
}
