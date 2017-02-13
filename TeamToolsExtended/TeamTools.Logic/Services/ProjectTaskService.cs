using Bytes2you.Validation;
using TeamTools.Logic.Data.Contracts;
using TeamTools.Logic.Data.Models;
using TeamTools.Logic.DTO;
using TeamTools.Logic.Services.Contracts;

namespace TeamTools.Logic.Services
{
    public class ProjectTaskService : IProjectTaskService
    {
        private readonly IRepository<ProjectTask> projectTasksRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapperService mapperService;

        public ProjectTaskService(
            IRepository<ProjectTask> projectTasksRepository,
            IUnitOfWork unitOfWork,
            IMapperService mapperService)
        {
            Guard.WhenArgument(projectTasksRepository, "ProjectTask Repository").IsNull().Throw();
            Guard.WhenArgument(unitOfWork, "UnitOfWork").IsNull().Throw();
            Guard.WhenArgument(mapperService, "Mapper Service").IsNull().Throw();

            this.projectTasksRepository = projectTasksRepository;
            this.unitOfWork = unitOfWork;
            this.mapperService = mapperService;
        }

        public void Create(ProjectTaskDTO projectTask)
        {
            var mappedProjectTask = this.mapperService.MapObject<ProjectTask>(projectTask);
            this.projectTasksRepository.Add(mappedProjectTask);
            this.unitOfWork.Commit();
        }

        public ProjectTaskDTO GetById(int id)
        {
            var projectTask = this.projectTasksRepository.GetById(id);
            var mappedProjectTask = this.mapperService.MapObject<ProjectTaskDTO>(projectTask);
            return mappedProjectTask;
        }

        public void Update(ProjectTaskDTO projectTask)
        {
            var mappedProjectTask = this.mapperService.MapObject<ProjectTask>(projectTask);
            this.projectTasksRepository.Update(mappedProjectTask);
            this.unitOfWork.Commit();
        }

        public void Delete(int id)
        {
            var taskToDelete = this.projectTasksRepository.GetById(id);
            taskToDelete.IsDeleted = true;
            this.projectTasksRepository.Update(taskToDelete);
            this.unitOfWork.Commit();
        }
    }
}
