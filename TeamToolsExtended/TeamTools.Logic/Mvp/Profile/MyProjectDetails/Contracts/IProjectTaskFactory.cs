using System;
using TeamTools.Logic.Data.Models.Enums;
using TeamTools.Logic.DTO;

namespace TeamTools.Logic.Mvp.Profile.MyProjectDetails.Contracts
{
    public interface IProjectTaskFactory
    {
        ProjectTaskDTO CreateProjectTask(string title, string description, DateTime? dueDate, decimal cost, TaskType status, int projectId);
    }
}
