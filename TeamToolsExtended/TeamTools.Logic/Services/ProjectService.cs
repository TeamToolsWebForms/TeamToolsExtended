using TeamTools.Logic.Data.Contracts;
using TeamTools.Logic.Data.Models;
using TeamTools.Logic.Services.Contracts;

namespace TeamTools.Logic.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IRepository<Project> projectRepository;
        private readonly IUnitOfWork unitOfWork;

        public ProjectService(IRepository<Project> projectRepository, IUnitOfWork unitOfWork)
        {
            this.projectRepository = projectRepository;
            this.unitOfWork = unitOfWork;
        }

        public void Delete(int id)
        {
            var searchedProject = this.projectRepository.GetById(id);
            searchedProject.IsDeleted = true;
            this.projectRepository.Update(searchedProject);
        }

        public void Update(int id, string newTitle)
        {
            var searchedProject = this.projectRepository.GetById(id);
            searchedProject.Title = newTitle;
            this.projectRepository.Update(searchedProject);
            this.unitOfWork.Commit();
        }
    }
}
