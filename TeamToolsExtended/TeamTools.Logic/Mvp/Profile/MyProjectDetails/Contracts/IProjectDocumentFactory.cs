using TeamTools.Logic.DTO;

namespace TeamTools.Logic.Mvp.Profile.MyProjectDetails.Contracts
{
    public interface IProjectDocumentFactory
    {
        ProjectDocumentDTO CreateProjectDocument(string filename, string fileExtension, byte[] fileContent, int projectId);
    }
}
