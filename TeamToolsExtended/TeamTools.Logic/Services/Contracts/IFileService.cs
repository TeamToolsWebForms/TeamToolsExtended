using TeamTools.Logic.DTO;

namespace TeamTools.Logic.Services.Contracts
{
    public interface IFileService
    {
        ProjectDocumentDTO DownloadFile(int id);

        void SaveDocument(string filename, string fileExtension, byte[] fileContent, int projectId);
    }
}