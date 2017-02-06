using TeamTools.Logic.DTO;

namespace TeamTools.Logic.Services.Contracts
{
    public interface IUserService
    {
        UserDTO GetById(string id);

        UserDTO GetByIdWithFilteredProjects(string id, string username);

        void Update(UserDTO note);
    }
}
