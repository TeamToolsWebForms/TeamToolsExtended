using TeamTools.Logic.Data.Contracts;
using TeamTools.Logic.Data.Models;
using TeamTools.Logic.Services.Contracts;

namespace TeamTools.Logic.Services
{
    public class ProjectTaskService : IProjectTaskService
    {
        private readonly IRepository<ProjectTask> projectTasksRepository;
        private readonly IUnitOfWork unitOfWork;

        public ProjectTaskService(IRepository<ProjectTask> projectTasksRepository, IUnitOfWork unitOfWork)
        {
            this.projectTasksRepository = projectTasksRepository;
            this.unitOfWork = unitOfWork;
        }

        public void Create(ProjectTask projectTask)
        {
            this.projectTasksRepository.Add(projectTask);
            this.unitOfWork.Commit();
        }
    }
}
