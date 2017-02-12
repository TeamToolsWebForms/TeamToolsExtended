using System;
using TeamTools.Logic.Data.Models;
using TeamTools.Logic.Data.Models.Enums;

namespace TeamTools.Logic.Mvp.Profile.MyProjectDetails.Contracts
{
    public interface IProjectTaskFactory
    {
        ProjectTask CreateProjectTask(string title, string description, DateTime? dueDate, decimal cost, TaskType status, int projectId);
    }
}
