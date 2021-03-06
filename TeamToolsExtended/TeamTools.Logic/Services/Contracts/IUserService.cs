﻿using System.Collections.Generic;
using TeamTools.Logic.DTO;

namespace TeamTools.Logic.Services.Contracts
{
    public interface IUserService
    {
        ICollection<UserDTO> GetAll();

        UserDTO GetById(string id);

        UserDTO GetByUsername(string username);

        IEnumerable<string> GetAllUsernamesWithoutMembers(string userId, int organizationId);

        UserDTO GetByIdWithFilteredProjects(string id, string username);

        void Update(UserDTO note);

        bool CheckIfBanned(string username);
    }
}
