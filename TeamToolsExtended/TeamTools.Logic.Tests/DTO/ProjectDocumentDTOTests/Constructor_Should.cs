using NUnit.Framework;
using TeamTools.Logic.DTO;

namespace TeamTools.Logic.Tests.DTO.ProjectDocumentDTOTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void CreateAnObjectOfTheSameTypeWithParameters()
        {
            string fileName = "filename";
            string fileExtension = "fileextension";
            var content = new byte[] { 1, 2, 3 };
            int projectId = 5;
            var projectDocumentDTO = new ProjectDocumentDTO(fileName, fileExtension, content, projectId);

            Assert.IsInstanceOf<ProjectDocumentDTO>(projectDocumentDTO);
        }

        [Test]
        public void CreateAnObjectOfTheSameTypeWithoutParameters()
        {
            var projectDto = new ProjectDocumentDTO();
            Assert.IsInstanceOf<ProjectDocumentDTO>(projectDto);
        }

        [Test]
        public void SetFileNameCorrectly()
        {
            string fileName = "filename";
            string fileExtension = "fileextension";
            var content = new byte[] { 1, 2, 3 };
            int projectId = 5;
            var projectDocumentDTO = new ProjectDocumentDTO(fileName, fileExtension, content, projectId);

            Assert.AreEqual(fileName, projectDocumentDTO.FileName);
        }

        [Test]
        public void SetFileExtensionCorrectly()
        {
            string fileName = "filename";
            string fileExtension = "fileextension";
            var content = new byte[] { 1, 2, 3 };
            int projectId = 5;
            var projectDocumentDTO = new ProjectDocumentDTO(fileName, fileExtension, content, projectId);

            Assert.AreEqual(fileExtension, projectDocumentDTO.FileExtension);
        }

        [Test]
        public void SetFileContentCorrectly()
        {
            string fileName = "filename";
            string fileExtension = "fileextension";
            var content = new byte[] { 1, 2, 3 };
            int projectId = 5;
            var projectDocumentDTO = new ProjectDocumentDTO(fileName, fileExtension, content, projectId);

            Assert.AreEqual(content, projectDocumentDTO.FileContent);
        }

        [Test]
        public void SetProjectIdCorrectly()
        {
            string fileName = "filename";
            string fileExtension = "fileextension";
            var content = new byte[] { 1, 2, 3 };
            int projectId = 5;
            var projectDocumentDTO = new ProjectDocumentDTO(fileName, fileExtension, content, projectId);

            Assert.AreEqual(projectId, projectDocumentDTO.ProjectId);
        }
    }
}
