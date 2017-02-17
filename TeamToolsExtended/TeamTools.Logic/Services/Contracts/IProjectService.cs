using TeamTools.Logic.DTO;

namespace TeamTools.Logic.Services.Contracts
{
    public interface IProjectService
    {
        ProjectDTO GetById(int id);

        ProjectDTO GetByIdSearchedDocuments(int id, string pattern);

        void Update(int id, string newTitle);

        void Delete(int id);

        void CreatePersonalProject(string projectName, string projectDescription, string username);

        void CreateOrganizationProject(int organizationId, string projectName, string projectDescription, string creatorName);
    }
}
