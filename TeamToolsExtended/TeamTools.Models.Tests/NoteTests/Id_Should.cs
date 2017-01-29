using NUnit.Framework;

namespace TeamTools.Models.Tests.NoteTests
{
    [TestFixture]
    public class Id_Should
    {
        [TestCase(1)]
        [TestCase(550)]
        public void SetId_Correct(int id)
        {
            var note = new Note();

            note.Id = id;

            Assert.AreEqual(id, note.Id);
        }
    }
}
