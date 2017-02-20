using System;
using NUnit.Framework;
using Moq;
using TeamTools.Logic.Services.Contracts;
using TeamTools.Logic.Data.Contracts;
using TeamTools.Logic.Services;
using TeamTools.Logic.Data.Models;

namespace TeamTools.Logic.Tests.Services.NoteServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowsWhenNoteRepository_IsNull()
        {
            var mockedMapper = new Mock<IMapperService>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var ex = Assert.Throws<ArgumentNullException>(() => new NoteService(
                null,
                mockedMapper.Object,
                mockedUnitOfWork.Object));

            Assert.That(ex.Message.Contains("Note Repository"));
        }

        [Test]
        public void ThrowsWhenMapperService_IsNull()
        {
            var mockedNoteRepository = new Mock<IRepository<Note>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var ex = Assert.Throws<ArgumentNullException>(() => new NoteService(
                mockedNoteRepository.Object,
                null,
                mockedUnitOfWork.Object));

            Assert.That(ex.Message.Contains("Mapper Service"));
        }

        [Test]
        public void ThrowsWhenUnitOfWork_IsNull()
        {
            var mockedNoteRepository = new Mock<IRepository<Note>>();
            var mockedMapper = new Mock<IMapperService>();

            var ex = Assert.Throws<ArgumentNullException>(() => new NoteService(
                mockedNoteRepository.Object,
                mockedMapper.Object,
                null));

            Assert.That(ex.Message.Contains("UnitOfWork"));
        }

        [Test]
        public void ReturnInstanceOfNoteService()
        {
            var mockedNoteRepository = new Mock<IRepository<Note>>();
            var mockedMapper = new Mock<IMapperService>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var noteService = new NoteService(
                mockedNoteRepository.Object,
                mockedMapper.Object,
                mockedUnitOfWork.Object);

            Assert.IsNotNull(noteService);
            Assert.IsInstanceOf<NoteService>(noteService);
        }
    }
}
