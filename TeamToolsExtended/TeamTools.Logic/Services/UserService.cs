using System.Linq;
using TeamTools.Logic.Data.Contracts;
using TeamTools.Logic.DTO;
using TeamTools.Logic.Data.Models;
using TeamTools.Logic.Services.Contracts;

namespace TeamTools.Logic.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> userRepository;
        private readonly IRepository<Project> projectRepository;
        private readonly IMapperService mapperService;
        private readonly IUnitOfWork unitOfWork;

        public UserService(
            IRepository<User> userRepository,
            IRepository<Project> projectRepository,
            IMapperService mapperService,
            IUnitOfWork unitOfWork)
        {
            this.userRepository = userRepository;
            this.projectRepository = projectRepository;
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
            var userProjects = this.projectRepository.All(x => x.IsPersonal == true && x.CreatorName == username && x.IsDeleted == false);
            user.Projects = userProjects.ToList();

            var mappedUser = this.mapperService.MapObject<UserDTO>(user);
            return mappedUser;
        }

        public void Update(UserDTO user)
        {
            var currentUser = this.userRepository.GetById(user.Id);
            var mappedUser = this.mapperService.MapObject(user, currentUser);
            this.unitOfWork.Commit();
        }
    }
}
