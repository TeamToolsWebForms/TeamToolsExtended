﻿using NUnit.Framework;
using Moq;

namespace TeamTools.Models.Tests.NoteTests
{
    [TestFixture]
    public class User_Should
    {
        [Test]
        public void SetUser_Correct()
        {
            var user = new Mock<User>();
            var note = new Note();

            note.User = user.Object;

            Assert.AreSame(user.Object, note.User);
        }

        [Test]
        public void BeVirtual()
        {
            var note = new Note();

            bool isVirtual = note.GetType().GetProperty("User").GetGetMethod().IsVirtual;

            Assert.IsTrue(isVirtual);
        }
    }
}
