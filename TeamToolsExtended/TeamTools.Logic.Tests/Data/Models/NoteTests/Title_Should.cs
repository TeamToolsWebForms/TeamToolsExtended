using System;
using NUnit.Framework;
using System.ComponentModel.DataAnnotations;
using TeamTools.Logic.Data.Models;

namespace TeamTools.Logic.Tests.Data.Models.NoteTests
{
    [TestFixture]
    public class Title_Should
    {
        [TestCase("ItOkay")]
        [TestCase("ItOkayToo")]
        public void SetTitle_Correct(string title)
        {
            var note = new Note();

            note.Title = title;

            Assert.AreEqual(title, note.Title);
        }

        [Test]
        public void HaveRequired_Attribute()
        {
            var note = new Note();

            var property = note.GetType().GetProperty("Title");
            bool isDefined = Attribute.IsDefined(property, typeof(RequiredAttribute));

            Assert.IsTrue(isDefined);
        }

        [Test]
        public void HaveMinLength_Attribute()
        {
            var note = new Note();

            var property = note.GetType().GetProperty("Title");
            bool isDefined = Attribute.IsDefined(property, typeof(MinLengthAttribute));

            Assert.IsTrue(isDefined);
        }

        [Test]
        public void HaveMaxLength_Attribute()
        {
            var note = new Note();

            var property = note.GetType().GetProperty("Title");
            bool isDefined = Attribute.IsDefined(property, typeof(MaxLengthAttribute));

            Assert.IsTrue(isDefined);
        }
    }
}
