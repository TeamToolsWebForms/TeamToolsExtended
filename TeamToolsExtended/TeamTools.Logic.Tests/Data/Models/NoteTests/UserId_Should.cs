using NUnit.Framework;
using TeamTools.Logic.Data.Models;

namespace TeamTools.Logic.Tests.Data.Models.NoteTests
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
