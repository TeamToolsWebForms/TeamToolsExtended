using System.Linq;
using AutoMapper;
using TeamTools.Data.Contracts;
using TeamTools.DataTransferObjects;
using TeamTools.Models;
using TeamTools.Services.Contracts;

namespace TeamTools.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> userRepository;
        private readonly IMapperService mapperService;

        public UserService(IRepository<User> userRepository, IMapperService mapperService)
        {
            this.userRepository = userRepository;
            this.mapperService = mapperService;
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
            user.Projects = user.Projects.Where(x => x.IsPersonal == true && x.CreatorName == username && x.IsDeleted == false).ToList();

            var mappedUser = this.mapperService.MapObject<UserDTO>(user);
            return mappedUser;
        }
    }
}
