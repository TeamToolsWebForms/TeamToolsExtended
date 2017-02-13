using TeamTools.Logic.DTO;

namespace TeamTools.Logic.Services.Contracts
{
    public interface IFileService
    {
        void SaveDocument(ProjectDocumentDTO projectDocument);
    }
}
