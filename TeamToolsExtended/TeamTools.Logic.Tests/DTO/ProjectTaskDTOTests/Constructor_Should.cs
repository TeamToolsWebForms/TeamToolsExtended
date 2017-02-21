using System;
using NUnit.Framework;
using TeamTools.Logic.DTO;
using TeamTools.Logic.Data.Models.Enums;

namespace TeamTools.Logic.Tests.DTO.ProjectTaskDTOTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void CreateAnObjextOfTheSameTypeWithParameters()
        {
            string title = "title";
            string description = "description";
            DateTime time = DateTime.Now;
            decimal cost = 5;
            TaskType type = TaskType.Done;
            int projectId = 5;

            var taskDto = new ProjectTaskDTO(title, description, time, cost, type, projectId);

            Assert.IsInstanceOf<ProjectTaskDTO>(taskDto);
        }

        [Test]
        public void CreateAnObjextOfTheSameTypeWithoutParameters()
        {
            var taskDto = new ProjectTaskDTO();
            Assert.IsInstanceOf<ProjectTaskDTO>(taskDto);
        }

        [Test]
        public void SetTitleCorrectly()
        {
            string title = "title";
            string description = "description";
            DateTime time = DateTime.Now;
            decimal cost = 5;
            TaskType type = TaskType.Done;
            int projectId = 5;

            var taskDto = new ProjectTaskDTO(title, description, time, cost, type, projectId);

            Assert.AreEqual(title, taskDto.Title);
        }

        [Test]
        public void SetDescriptionCorrectly()
        {
            string title = "title";
            string description = "description";
            DateTime time = DateTime.Now;
            decimal cost = 5;
            TaskType type = TaskType.Done;
            int projectId = 5;

            var taskDto = new ProjectTaskDTO(title, description, time, cost, type, projectId);

            Assert.AreEqual(description, taskDto.Description);
        }

        [Test]
        public void SetTimeCorrectly()
        {
            string title = "title";
            string description = "description";
            DateTime time = DateTime.Now;
            decimal cost = 5;
            TaskType type = TaskType.Done;
            int projectId = 5;

            var taskDto = new ProjectTaskDTO(title, description, time, cost, type, projectId);

            Assert.AreEqual(time, taskDto.DueDate);
        }

        [Test]
        public void SetCostCorrectly()
        {
            string title = "title";
            string description = "description";
            DateTime time = DateTime.Now;
            decimal cost = 5;
            TaskType type = TaskType.Done;
            int projectId = 5;

            var taskDto = new ProjectTaskDTO(title, description, time, cost, type, projectId);

            Assert.AreEqual(cost, taskDto.ExecutionCost);
        }

        [Test]
        public void SetTaskTypeCorrectly()
        {
            string title = "title";
            string description = "description";
            DateTime time = DateTime.Now;
            decimal cost = 5;
            TaskType type = TaskType.Done;
            int projectId = 5;

            var taskDto = new ProjectTaskDTO(title, description, time, cost, type, projectId);

            Assert.AreEqual(type, taskDto.Status);
        }

        [Test]
        public void SetProjectIdCorrectly()
        {
            string title = "title";
            string description = "description";
            DateTime time = DateTime.Now;
            decimal cost = 5;
            TaskType type = TaskType.Done;
            int projectId = 5;

            var taskDto = new ProjectTaskDTO(title, description, time, cost, type, projectId);

            Assert.AreEqual(projectId, taskDto.ProjectId);
        }
    }
}
