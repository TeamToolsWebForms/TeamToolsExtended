using TeamTools.Logic.DTO;

namespace TeamTools.Logic.Services.Contracts
{
    public interface IProjectTaskService
    {
        void Create(ProjectTaskDTO projectTask);

        ProjectTaskDTO GetById(int id);

        void Update(ProjectTaskDTO projectTask);

        void Delete(int id);
    }
}
