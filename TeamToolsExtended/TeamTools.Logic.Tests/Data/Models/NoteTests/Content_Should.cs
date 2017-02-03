using System;
using NUnit.Framework;
using System.ComponentModel.DataAnnotations;
using TeamTools.Logic.Data.Models;

namespace TeamTools.Logic.Tests.Data.Models.NoteTests
{
    [TestFixture]
    public class Content_Should
    {
        [TestCase("OkayOkay")]
        [TestCase("OkayOkayAgain")]
        public void SetContent_Correct(string content)
        {
            var note = new Note();

            note.Content = content;

            Assert.AreEqual(content, note.Content);
        }

        [Test]
        public void HaveMinLength_Attribute()
        {
            var note = new Note();

            var property = note.GetType().GetProperty("Content");
            bool isDefined = Attribute.IsDefined(property, typeof(MinLengthAttribute));

            Assert.IsTrue(isDefined);
        }

        [Test]
        public void HaveMaxLength_Attribute()
        {
            var note = new Note();

            var property = note.GetType().GetProperty("Content");
            bool isDefined = Attribute.IsDefined(property, typeof(MaxLengthAttribute));

            Assert.IsTrue(isDefined);
        }
    }
}
