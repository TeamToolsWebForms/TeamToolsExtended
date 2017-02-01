using TeamTools.DataTransferObjects;

namespace TeamTools.Services.Contracts
{
    public interface IUserService
    {
        UserDTO GetById(string id);

        UserDTO GetByIdWithFilteredProjects(string id, string username);
    }
}
