using System;
using TeamTools.Logic.Data.Models.Enums;

namespace TeamTools.Logic.Mvp.Profile.MyProjectDetails
{
    public class ProjectDetailsEventArgs : EventArgs
    {
        public ProjectDetailsEventArgs(int projectId)
        {
            this.ProjectId = projectId;
        }

        public ProjectDetailsEventArgs(
            string title,
            string description,
            DateTime? executionTime,
            decimal executionCost,
            TaskType status,
            int projectId)
            : this(projectId)
        {
            this.TaskTitle = title;
            this.TaskDescription = description;
            this.DueDate = executionTime;
            this.TaskExecutionCost = executionCost;
            this.TaskStatus = status;
        }

        public int ProjectId { get; set; }

        public string TaskTitle { get; set; }

        public string TaskDescription { get; set; }

        public DateTime? DueDate { get; set; }

        public decimal TaskExecutionCost { get; set; }

        public TaskType TaskStatus { get; set; }
    }
}
