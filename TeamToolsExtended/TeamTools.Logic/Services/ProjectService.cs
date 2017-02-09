using TeamTools.Logic.Data.Contracts;
using TeamTools.Logic.Data.Models;
using TeamTools.Logic.Mvp.Profile.MyProjects.Contracts;
using TeamTools.Logic.Services.Contracts;

namespace TeamTools.Logic.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IRepository<Project> projectRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IProjectFactory projectFactory;

        public ProjectService(IRepository<Project> projectRepository, IUnitOfWork unitOfWork, IProjectFactory projectFactory)
        {
            this.projectRepository = projectRepository;
            this.unitOfWork = unitOfWork;
            this.projectFactory = projectFactory;
        }

        public void Delete(int id)
        {
            var searchedProject = this.projectRepository.GetById(id);
            searchedProject.IsDeleted = true;
            this.projectRepository.Update(searchedProject);
            this.unitOfWork.Commit();
        }

        public void Update(int id, string newTitle)
        {
            var searchedProject = this.projectRepository.GetById(id);
            searchedProject.Title = newTitle;
            this.projectRepository.Update(searchedProject);
            this.unitOfWork.Commit();
        }

        public void CreatePersonalProject(string projectName, string projectDescription, string username)
        {
            var newProject = this.projectFactory.CreateProject(projectName, projectDescription, username);
            newProject.IsPersonal = true;
            this.projectRepository.Add(newProject);
            this.unitOfWork.Commit();
        }
    }
}
