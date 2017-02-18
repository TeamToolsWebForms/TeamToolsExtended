using System;
using TeamTools.Logic.Data.Models.Enums;
using TeamTools.Logic.DTO;

namespace TeamTools.Logic.Services.Contracts
{
    public interface IProjectTaskService
    {
        void Create(ProjectTaskDTO projectTask);

        ProjectTaskDTO GetById(int id);

        void Update(int taskId, string title, string description, DateTime? dueDate, decimal cost, TaskType status);

        void Delete(int id);

        void AssignUserToTask(int id, string username);

        bool IsUserToAssignValid(int id, string username);

        string GetUsersNotSignedToTask(int taskId, int projectId);
    }
}
