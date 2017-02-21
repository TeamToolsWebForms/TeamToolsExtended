using Bytes2you.Validation;
using System.Linq;
using TeamTools.Logic.Mvp.Profile.MyProjectDetails.Contracts;
using TeamTools.Logic.Services.Contracts;
using WebFormsMvp;

namespace TeamTools.Logic.Mvp.Profile.MyProjectDetails
{
    public class ProjectDetailsChartPresenter : Presenter<IProjectDetailsChartView>
    {
        private readonly IProjectService projectService;

        public ProjectDetailsChartPresenter(IProjectDetailsChartView view, IProjectService projectService)
            : base(view)
        {
            Guard.WhenArgument(projectService, "Project service").IsNull().Throw();

            this.View.LoadProject += this.View_LoadProject;

            this.projectService = projectService;
        }

        private void View_LoadProject(object sender, ProjectDetailsEventArgs e)
        {
            this.View.Model.Project = this.projectService.GetById(e.Id);
            this.View.Model.AllCosts = this.View.Model.Project.ProjectTasks.Select(t => t.ExecutionCost).ToArray();
            this.View.Model.AllDays = string.Join(",", this.View.Model.Project.ProjectTasks.Where(t => t.DueDate != null).Select(t => t.DueDate.Value.Day).ToList());
            this.View.Model.TotalDays = this.View.Model.Project.ProjectTasks.Where(t => t.DueDate != null).Select(t => t.DueDate.Value.Day).ToList().Sum();
            this.View.Model.TotalCost = this.View.Model.Project.ProjectTasks.Select(t => t.ExecutionCost).ToList().Sum();
        }
    }
}
