﻿using System;
using System.Collections.Generic;
using TeamTools.Logic.Data.Models.Enums;

namespace TeamTools.Logic.DTO
{
    public class ProjectTaskDTO
    {
        public ProjectTaskDTO()
        {
        }

        public ProjectTaskDTO(string title, string description, DateTime? dueDate, decimal cost, TaskType status, int projectId)
        {
            this.Title = title;
            this.Description = description;
            this.DueDate = dueDate;
            this.ExecutionCost = cost;
            this.Status = status;
            this.ProjectId = projectId;
        }

        public int Id { get; set; }

        public string Title { get; set; }
        
        public string Description { get; set; }
        
        public DateTime? DueDate { get; set; }

        public decimal ExecutionCost { get; set; }

        public TaskType Status { get; set; }

        public int ProjectId { get; set; }

        public ProjectDTO Project { get; set; }
        
        public ICollection<UserDTO> Users;
    }
}
