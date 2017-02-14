namespace TeamTools.Logic.Services.Contracts
{
    public interface IFileService
    {
        void SaveDocument(string filename, string fileExtension, byte[] fileContent, int projectId);
    }
}