using System.Linq;
using TeamTools.Logic.Data.Contracts;
using TeamTools.Logic.DTO;
using TeamTools.Logic.Data.Models;
using TeamTools.Logic.Services.Contracts;
using System.Collections.Generic;
using Bytes2you.Validation;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TeamTools.Logic.Services
{
    public class UserService : IUserService
    {
        private const string BannedRoleId = "2";
        private readonly IRepository<User> userRepository;
        private readonly IRepository<Project> projectRepository;
        private readonly IRepository<Organization> organizationRepository;
        private readonly IRepository<IdentityUserRole> roleRepository;
        private readonly IMapperService mapperService;
        private readonly IUnitOfWork unitOfWork;

        public UserService(
            IRepository<User> userRepository,
            IRepository<Project> projectRepository,
            IRepository<Organization> organizationRepository,
            IRepository<IdentityUserRole> roleRepository,
            IMapperService mapperService,
            IUnitOfWork unitOfWork)
        {
            Guard.WhenArgument(userRepository, "User Repository").IsNull().Throw();
            Guard.WhenArgument(projectRepository, "Project Repository").IsNull().Throw();
            Guard.WhenArgument(organizationRepository, "Organization Repository").IsNull().Throw();
            Guard.WhenArgument(mapperService, "Mapper Service").IsNull().Throw();
            Guard.WhenArgument(unitOfWork, "UnitOfWork").IsNull().Throw();

            this.userRepository = userRepository;
            this.projectRepository = projectRepository;
            this.organizationRepository = organizationRepository;
            this.roleRepository = roleRepository;
            this.mapperService = mapperService;
            this.unitOfWork = unitOfWork;
        }

        public UserDTO GetById(string id)
        {
            var user = this.userRepository.GetById(id);
            var mappedUser = this.mapperService.MapObject<UserDTO>(user);
            return mappedUser;
        }

        public UserDTO GetByIdWithFilteredProjects(string id, string username)
        {
            var user = this.userRepository.GetById(id);
            user.Projects.Clear();
            var userProjects = this.projectRepository.All(x => x.IsPersonal == true && x.CreatorName == username && x.IsDeleted == false);
            user.Projects = userProjects.ToList();

            var mappedUser = this.mapperService.MapObject<UserDTO>(user);
            return mappedUser;
        }

        public void Update(UserDTO user)
        {
            var currentUser = this.userRepository.GetById(user.Id);
            var mappedLogo = this.mapperService.MapObject<UserLogo>(user.UserLogo);
            currentUser.UserLogo = mappedLogo;
            this.userRepository.Update(currentUser);
            this.unitOfWork.Commit();
        }

        public UserDTO GetByUsername(string username)
        {
            var user = this.userRepository.All(x => x.UserName == username).FirstOrDefault();
            var mapperUser = this.mapperService.MapObject<UserDTO>(user);
            return mapperUser;
        }

        public IEnumerable<string> GetAllUsernamesWithoutMembers(string userId, int organizationId)
        {
            var organization = this.organizationRepository.GetById(organizationId);
            var users = this.userRepository.All().Where(x => !organization.Users.Contains(x)).Select(u => u.UserName);
            return users;
        }

        public bool CheckIfBanned(string username)
        {
            var user = this.userRepository.All(x => x.UserName == username).FirstOrDefault();
            var role = this.roleRepository.All(x => x.RoleId == BannedRoleId).FirstOrDefault();
            bool isBanned = user.Roles.Contains(role);
            return isBanned;
        }

        public ICollection<UserDTO> GetAll()
        {
            return this.userRepository.All().Select(x => this.mapperService.MapObject<UserDTO>(x)).ToList();
        }
    }
}
