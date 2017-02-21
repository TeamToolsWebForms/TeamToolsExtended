using NUnit.Framework;
using TeamTools.Logic.DTO;

namespace TeamTools.Logic.Tests.DTO.NoteDTOTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void CreateAnObjectOfTheSameType()
        {
            var content = "content";
            var title = "title";
            var userId = "id";
            var note = new NoteDTO(title, content, userId);

            Assert.IsInstanceOf<NoteDTO>(note);
        }

        [Test]
        public void SetTitleCorrectly()
        {
            var content = "content";
            var title = "title";
            var userId = "id";
            var note = new NoteDTO(title, content, userId);

            Assert.AreEqual(note.Title, title);
        }

        [Test]
        public void SetContentCorrectly()
        {
            var content = "content";
            var title = "title";
            var userId = "id";
            var note = new NoteDTO(title, content, userId);

            Assert.AreEqual(note.Content, content);
        }

        [Test]
        public void SetUserIdCorrectly()
        {
            var content = "content";
            var title = "title";
            var userId = "id";
            var note = new NoteDTO(title, content, userId);

            Assert.AreEqual(note.UserId, userId);
        }
    }
}
