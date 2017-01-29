using NUnit.Framework;

namespace TeamTools.Models.Tests.NoteTests
{
    [TestFixture]
    public class UserId_Should
    {
        [TestCase(1)]
        [TestCase(20)]
        public void SetUserId_Correct(int id)
        {
            var note = new Note();

            note.UserId = id;

            Assert.AreEqual(id, note.UserId);
        }
    }
}
