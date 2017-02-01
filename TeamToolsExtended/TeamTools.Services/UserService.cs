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

        public UserService(IRepository<User> userRepository)
        {
            this.userRepository = userRepository;
        }

        public UserDTO GetById(string id)
        {
            var user = this.userRepository.GetById(id);
            // cannot test mapper
            var mappedUser = Mapper.Map<UserDTO>(user);
            return mappedUser;
        }

        public UserDTO GetByIdWithFilteredProjects(string id, string username)
        {
            var user = this.userRepository.GetById(id);
            user.Projects = user.Projects.Where(x => x.IsPersonal == true && x.CreatorName == username).ToList();

            var mappedUser = Mapper.Map<UserDTO>(user);
            return mappedUser;
        }
    }
}
