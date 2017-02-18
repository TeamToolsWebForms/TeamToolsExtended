using Bytes2you.Validation;
using System.Linq;
using TeamTools.Logic.Data.Contracts;
using TeamTools.Logic.Data.Models;
using TeamTools.Logic.DTO;
using TeamTools.Logic.Mvp.Profile.MyProjects.Contracts;
using TeamTools.Logic.Services.Contracts;
using System;

namespace TeamTools.Logic.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IRepository<Project> projectRepository;
        private readonly IRepository<Organization> organizationRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IProjectFactory projectFactory;
        private readonly IMapperService mapperService;
        private readonly IJsonService jsonService;

        public ProjectService(
            IRepository<Project> projectRepository,
            IRepository<Organization> organizationRepository,
            IUnitOfWork unitOfWork,
            IProjectFactory projectFactory,
            IMapperService mapperService,
            IJsonService jsonService)
        {
            Guard.WhenArgument(projectRepository, "Project Repository").IsNull().Throw();
            Guard.WhenArgument(organizationRepository, "Organization Repository").IsNull().Throw();
            Guard.WhenArgument(unitOfWork, "Unit of work").IsNull().Throw();
            Guard.WhenArgument(projectFactory, "Project Factory").IsNull().Throw();
            Guard.WhenArgument(mapperService, "Mapper Service").IsNull().Throw();
            Guard.WhenArgument(jsonService, "Json Service").IsNull().Throw();

            this.projectRepository = projectRepository;
            this.organizationRepository = organizationRepository;
            this.unitOfWork = unitOfWork;
            this.projectFactory = projectFactory;
            this.mapperService = mapperService;
            this.jsonService = jsonService;
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

        public ProjectDTO GetById(int id)
        {
            var project = this.projectRepository.GetById(id);
            var filteredTasks = project.ProjectTasks.Where(t => t.IsDeleted == false).ToList();
            project.ProjectTasks.Clear();
            project.ProjectTasks = filteredTasks;
            var mappedProject = this.mapperService.MapObject<ProjectDTO>(project);
            return mappedProject;
        }

        public ProjectDTO GetByIdSearchedDocuments(int id, string pattern)
        {
            var project = this.projectRepository.GetById(id);
            var mappedProject = this.mapperService.MapObject<ProjectDTO>(project);
            mappedProject.ProjectDocuments = mappedProject.ProjectDocuments.Where(d => d.FileName.ToLower().Contains(pattern.ToLower())).ToList();
            return mappedProject;
        }

        public void CreateOrganizationProject(int organizationId, string projectName, string projectDescription, string creatorName)
        {
            var organization = this.organizationRepository.GetById(organizationId);
            var newProject = this.projectFactory.CreateProject(projectName, projectDescription, creatorName);
            this.projectRepository.Add(newProject);
            organization.Projects.Add(newProject);
            this.unitOfWork.Commit();
        }

        public string GetUnsignedOrgUsersToProject(int id, int organizationId)
        {
            var organization = this.organizationRepository.GetById(organizationId);
            var project = this.projectRepository.GetById(id);
            var users = organization.Users.Except(project.Users).Select(x => x.UserName);
            string usersJson = this.jsonService.GetAsJson(users);
            return usersJson;
        }

        public bool IsUserValid(int organizationId, string username)
        {
            var organization = this.organizationRepository.GetById(organizationId);
            bool isValid = organization.Users.Any(x => x.UserName == username);

            return isValid;
        }

        public void AddUserToProject(int projectId, int organizationId, string username)
        {
            var organization = this.organizationRepository.GetById(organizationId);
            var project = this.projectRepository.GetById(projectId);
            var user = organization.Users.FirstOrDefault(x => x.UserName == username);
            project.Users.Add(user);
            this.unitOfWork.Commit();
        }
    }
}
