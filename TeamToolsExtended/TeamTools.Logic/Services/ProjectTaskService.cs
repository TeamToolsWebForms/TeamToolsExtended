using Bytes2you.Validation;
using System;
using System.Linq;
using TeamTools.Logic.Data.Contracts;
using TeamTools.Logic.Data.Models;
using TeamTools.Logic.Data.Models.Enums;
using TeamTools.Logic.DTO;
using TeamTools.Logic.Services.Contracts;

namespace TeamTools.Logic.Services
{
    public class ProjectTaskService : IProjectTaskService
    {
        private readonly IRepository<ProjectTask> projectTasksRepository;
        private readonly IRepository<Project> projectRepository;
        private readonly IRepository<User> userRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapperService mapperService;
        private readonly IJsonService jsonService;

        public ProjectTaskService(
            IRepository<ProjectTask> projectTasksRepository,
            IRepository<Project> projectRepository,
            IRepository<User> userRepository,
            IUnitOfWork unitOfWork,
            IMapperService mapperService,
            IJsonService jsonService)
        {
            Guard.WhenArgument(projectTasksRepository, "ProjectTask Repository").IsNull().Throw();
            Guard.WhenArgument(projectRepository, "Project Repository").IsNull().Throw();
            Guard.WhenArgument(userRepository, "User Repository").IsNull().Throw();
            Guard.WhenArgument(unitOfWork, "UnitOfWork").IsNull().Throw();
            Guard.WhenArgument(mapperService, "Mapper Service").IsNull().Throw();
            Guard.WhenArgument(jsonService, "Json Service").IsNull().Throw();

            this.projectTasksRepository = projectTasksRepository;
            this.projectRepository = projectRepository;
            this.userRepository = userRepository;
            this.unitOfWork = unitOfWork;
            this.mapperService = mapperService;
            this.jsonService = jsonService;
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

        public void Update(int taskId, string title, string description, DateTime? dueDate, decimal cost, TaskType status)
        {
            var task = this.projectTasksRepository.GetById(taskId);

            task.Title = title;
            task.Description = description;
            task.DueDate = dueDate;
            task.ExecutionCost = cost;
            task.Status = status;

            this.projectTasksRepository.Update(task);
            this.unitOfWork.Commit();
        }

        public void Delete(int id)
        {
            var taskToDelete = this.projectTasksRepository.GetById(id);
            taskToDelete.IsDeleted = true;
            this.projectTasksRepository.Update(taskToDelete);
            this.unitOfWork.Commit();
        }

        public void AssignUserToTask(int id, string username)
        {
            var task = this.projectTasksRepository.GetById(id);
            var user = this.userRepository.All(x => x.UserName == username).FirstOrDefault();

            Guard.WhenArgument(user, "User").IsNull().Throw();

            task.Users.Add(user);
            this.unitOfWork.Commit();
        }

        public bool IsUserToAssignValid(int id, string username)
        {
            var task = this.projectTasksRepository.GetById(id);
            bool isValid = task.Users.Any(x => x.UserName == username);
            return isValid;
        }

        public string GetUsersNotSignedToTask(int taskId, int projectId)
        {
            var project = this.projectRepository.GetById(projectId);
            var task = this.projectTasksRepository.GetById(taskId);

            var users = project.Users.Except(task.Users).Select(x => x.UserName);
            string usersJson = this.jsonService.GetAsJson(users);
            return usersJson;
        }
    }
}
