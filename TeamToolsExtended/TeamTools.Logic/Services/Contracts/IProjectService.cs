namespace TeamTools.Logic.Services.Contracts
{
    public interface IProjectService
    {
        void Update(int id, string newTitle);

        void Delete(int id);

        void CreatePersonalProject(string projectName, string projectDescription, string username);
    }
}
