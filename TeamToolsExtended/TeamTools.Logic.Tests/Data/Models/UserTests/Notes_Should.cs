using System.Collections.Generic;
using NUnit.Framework;
using TeamTools.Logic.Data.Models;

namespace TeamTools.Logic.Tests.Data.Models.UserTests
{
    [TestFixture]
    public class Notes_Should
    {
        [Test]
        public void SetNotes_Correct()
        {
            var notes = new HashSet<Note>();
            var user = new User();

            user.Notes = notes;

            Assert.AreSame(notes, user.Notes);
        }

        [Test]
        public void BeVirtual()
        {
            var user = new User();

            bool isVirtual = user.GetType().GetProperty("Notes").GetGetMethod().IsVirtual;

            Assert.IsTrue(isVirtual);
        }
    }
}
