using System;
using TeamTools.Logic.Data.Models.Enums;

namespace TeamTools.Logic.Mvp.Profile.MyProjectDetails
{
    public class ProjectDetailsEventArgs : EventArgs
    {
        public ProjectDetailsEventArgs(int id)
        {
            this.Id = id;
        }

        public ProjectDetailsEventArgs(int id, string filename, string fileExtension, byte[] fileContent)
            : this(id)
        {
            this.FileName = filename;
            this.FileExtension = fileExtension;
            this.FileContent = fileContent;
        }

        public ProjectDetailsEventArgs(
            string title,
            string description,
            DateTime? executionTime,
            decimal executionCost,
            TaskType status,
            int id)
            : this(id)
        {
            this.TaskTitle = title;
            this.TaskDescription = description;
            this.DueDate = executionTime;
            this.TaskExecutionCost = executionCost;
            this.TaskStatus = status;
        }

        public int Id { get; set; }

        public string TaskTitle { get; set; }

        public string TaskDescription { get; set; }

        public DateTime? DueDate { get; set; }

        public decimal TaskExecutionCost { get; set; }

        public TaskType TaskStatus { get; set; }

        public byte[] FileContent { get; set; }

        public string FileName { get; set; }

        public string FileExtension { get; set; }
    }
}
