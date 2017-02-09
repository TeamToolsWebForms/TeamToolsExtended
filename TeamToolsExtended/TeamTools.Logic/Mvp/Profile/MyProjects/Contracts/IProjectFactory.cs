using TeamTools.Logic.Data.Models;

namespace TeamTools.Logic.Mvp.Profile.MyProjects.Contracts
{
    public interface IProjectFactory
    {
        Project CreateProject(string title, string description, string username);
    }
}
