using System;
using System.Collections.Generic;
using NUnit.Framework;
using Moq;
using TeamTools.Logic.Mvp.Profile.MyProjectDetails.Contracts;
using TeamTools.Logic.Services.Contracts;
using TeamTools.Logic.Mvp.Profile.MyProjectDetails;
using TeamTools.Logic.DTO;

namespace TeamTools.Logic.Tests.Mvp.Profile.MyProjectDetails.ProjectDetailsChartPresenterTests
{
    [TestFixture]
    public class View_LoadProject_Should
    {
        [Test]
        public void SetViewModelProject_Correct()
        {
            var mockedView = new Mock<IProjectDetailsChartView>();
            var viewModel = new ProjectDetailsViewModel();
            mockedView.Setup(x => x.Model).Returns(viewModel);
            var mockedProjectService = new Mock<IProjectService>();
            var projectDTO = new ProjectDTO();
            projectDTO.ProjectTasks = new List<ProjectTaskDTO>();
            mockedProjectService.Setup(x => x.GetById(It.IsAny<int>())).Returns(projectDTO);

            var presenter = new ProjectDetailsChartPresenter(mockedView.Object, mockedProjectService.Object);
            int id = 12;

            mockedView.Raise(x => x.LoadProject += null, new ProjectDetailsEventArgs(id));

            Assert.AreEqual(mockedView.Object.Model.Project, projectDTO);
        }

        [Test]
        public void SetViewModelAllCosts_Correct()
        {
            var mockedView = new Mock<IProjectDetailsChartView>();
            var viewModel = new ProjectDetailsViewModel();
            mockedView.Setup(x => x.Model).Returns(viewModel);
            var mockedProjectService = new Mock<IProjectService>();
            var projectDTO = new ProjectDTO();
            projectDTO.ProjectTasks = new List<ProjectTaskDTO>()
            {
                new ProjectTaskDTO() { ExecutionCost = 1 },
                new ProjectTaskDTO() { ExecutionCost = 2 },
                new ProjectTaskDTO() { ExecutionCost = 3 }
            };
            mockedProjectService.Setup(x => x.GetById(It.IsAny<int>())).Returns(projectDTO);

            var presenter = new ProjectDetailsChartPresenter(mockedView.Object, mockedProjectService.Object);
            int id = 12;
            decimal[] expected = new decimal[] { 1, 2, 3 };

            mockedView.Raise(x => x.LoadProject += null, new ProjectDetailsEventArgs(id));

            CollectionAssert.AreEquivalent(mockedView.Object.Model.AllCosts, expected);
        }

        [Test]
        public void SetViewModelAllDays_Correct()
        {
            var mockedView = new Mock<IProjectDetailsChartView>();
            var viewModel = new ProjectDetailsViewModel();
            mockedView.Setup(x => x.Model).Returns(viewModel);
            var mockedProjectService = new Mock<IProjectService>();
            var projectDTO = new ProjectDTO();
            projectDTO.ProjectTasks = new List<ProjectTaskDTO>()
            {
                new ProjectTaskDTO() { DueDate = new DateTime(2000, 10, 22) },
                new ProjectTaskDTO() { DueDate = new DateTime(2000, 10, 23) },
                new ProjectTaskDTO() { DueDate = new DateTime(2000, 10, 24) }
            };
            mockedProjectService.Setup(x => x.GetById(It.IsAny<int>())).Returns(projectDTO);

            var presenter = new ProjectDetailsChartPresenter(mockedView.Object, mockedProjectService.Object);
            int id = 12;
            string expected = "22,23,24";

            mockedView.Raise(x => x.LoadProject += null, new ProjectDetailsEventArgs(id));

            Assert.AreEqual(mockedView.Object.Model.AllDays, expected);
        }

        [Test]
        public void SetViewModelTotalDays_Correct()
        {
            var mockedView = new Mock<IProjectDetailsChartView>();
            var viewModel = new ProjectDetailsViewModel();
            mockedView.Setup(x => x.Model).Returns(viewModel);
            var mockedProjectService = new Mock<IProjectService>();
            var projectDTO = new ProjectDTO();
            projectDTO.ProjectTasks = new List<ProjectTaskDTO>()
            {
                new ProjectTaskDTO() { DueDate = new DateTime(2000, 10, 1) },
                new ProjectTaskDTO() { DueDate = new DateTime(2000, 10, 2) },
                new ProjectTaskDTO() { DueDate = new DateTime(2000, 10, 3) }
            };
            mockedProjectService.Setup(x => x.GetById(It.IsAny<int>())).Returns(projectDTO);

            var presenter = new ProjectDetailsChartPresenter(mockedView.Object, mockedProjectService.Object);
            int id = 12;
            int expected = 6;

            mockedView.Raise(x => x.LoadProject += null, new ProjectDetailsEventArgs(id));

            Assert.AreEqual(mockedView.Object.Model.TotalDays, expected);
        }

        [Test]
        public void SetViewModelTotalCost_Correct()
        {
            var mockedView = new Mock<IProjectDetailsChartView>();
            var viewModel = new ProjectDetailsViewModel();
            mockedView.Setup(x => x.Model).Returns(viewModel);
            var mockedProjectService = new Mock<IProjectService>();
            var projectDTO = new ProjectDTO();
            projectDTO.ProjectTasks = new List<ProjectTaskDTO>()
            {
                new ProjectTaskDTO() { ExecutionCost = 2 },
                new ProjectTaskDTO() { ExecutionCost = 2 },
                new ProjectTaskDTO() { ExecutionCost = 2 }
            };
            mockedProjectService.Setup(x => x.GetById(It.IsAny<int>())).Returns(projectDTO);

            var presenter = new ProjectDetailsChartPresenter(mockedView.Object, mockedProjectService.Object);
            int id = 12;
            int expected = 6;

            mockedView.Raise(x => x.LoadProject += null, new ProjectDetailsEventArgs(id));

            Assert.AreEqual(mockedView.Object.Model.TotalCost, expected);
        }
    }
}
