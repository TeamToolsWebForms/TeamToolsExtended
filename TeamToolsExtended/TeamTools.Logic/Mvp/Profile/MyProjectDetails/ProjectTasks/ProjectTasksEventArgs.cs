﻿using System;
using TeamTools.Logic.Data.Models.Enums;

namespace TeamTools.Logic.Mvp.Profile.MyProjectDetails.ProjectTasks
{
    public class ProjectTasksEventArgs : EventArgs
    {
        public ProjectTasksEventArgs(int projectId)
        {
            this.ProjectId = projectId;
        }

        public ProjectTasksEventArgs(
            string title,
            string description,
            string executionTime,
            decimal executionCost,
            TaskType status)
        {
            this.TaskTitle = title;
            this.TaskDescription = description;
            this.TaskExecutionTime = executionTime;
            this.TaskExecutionCost = executionCost;
            this.TaskStatus = status;
        }

        public int ProjectId { get; set; }

        public string TaskTitle { get; set; }

        public string TaskDescription { get; set; }

        public string TaskExecutionTime { get; set; }

        public decimal TaskExecutionCost { get; set; }

        public TaskType TaskStatus { get; set; }
    }
}
