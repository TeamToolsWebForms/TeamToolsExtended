using TeamTools.Logic.Data.Models;
using TeamTools.Logic.DTO;

namespace TeamTools.Logic.Services.Contracts
{
    public interface IUserService
    {
        UserDTO GetById(string id);

        UserDTO GetByUsername(string username);

        UserDTO GetByIdWithFilteredProjects(string id, string username);

        void Update(UserDTO note);
    }
}
