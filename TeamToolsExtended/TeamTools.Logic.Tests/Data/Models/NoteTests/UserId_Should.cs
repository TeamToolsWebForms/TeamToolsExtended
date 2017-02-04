using NUnit.Framework;
using TeamTools.Logic.Data.Models;

namespace TeamTools.Logic.Tests.Data.Models.NoteTests
{
    [TestFixture]
    public class UserId_Should
    {
        [TestCase("ssaf-2")]
        [TestCase("safdadsfa=dsf")]
        public void SetUserId_Correct(string id)
        {
            var note = new Note();

            note.UserId = id;

            Assert.AreEqual(id, note.UserId);
        }
    }
}
