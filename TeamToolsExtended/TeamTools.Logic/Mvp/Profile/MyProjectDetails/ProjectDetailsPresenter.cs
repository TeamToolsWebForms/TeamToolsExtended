using Bytes2you.Validation;
using TeamTools.Logic.Mvp.Profile.MyProjectDetails.Contracts;
using TeamTools.Logic.Services.Contracts;
using WebFormsMvp;

namespace TeamTools.Logic.Mvp.Profile.MyProjectDetails
{
    public class ProjectDetailsPresenter : Presenter<IProjectDetailsView>
    {
        private readonly IProjectService projectService;

        public ProjectDetailsPresenter(
            IProjectDetailsView view,
            IProjectService projectService)
            : base(view)
        {
            Guard.WhenArgument(projectService, "Project service").IsNull().Throw();

            this.View.DeleteProject += this.View_DeleteProject;

            this.projectService = projectService;
        }

        private void View_DeleteProject(object sender, ProjectDetailsEventArgs e)
        {
            this.projectService.Delete(e.Id);
        }
    }
}
