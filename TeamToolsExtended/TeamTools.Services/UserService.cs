using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            var mappedUser = Mapper.Map<UserDTO>(user);
            return mappedUser;
        }
    }
}
