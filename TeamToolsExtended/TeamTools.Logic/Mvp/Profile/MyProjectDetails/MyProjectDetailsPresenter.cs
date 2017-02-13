using Bytes2you.Validation;
using TeamTools.Logic.Mvp.Profile.MyProjectDetails.Contracts;
using TeamTools.Logic.Services.Contracts;
using WebFormsMvp;

namespace TeamTools.Logic.Mvp.Profile.MyProjectDetails
{
    public class MyProjectDetailsPresenter : Presenter<IMyProjectDetailsView>
    {
        private readonly IProjectService projectService;

        public MyProjectDetailsPresenter(IMyProjectDetailsView view, IProjectService projectService)
            : base(view)
        {
            Guard.WhenArgument(view, "View").IsNull().Throw();
            Guard.WhenArgument(projectService, "Project service").IsNull().Throw();

            this.View.DeleteProject += View_DeleteProject;

            this.projectService = projectService;
        }

        private void View_DeleteProject(object sender, ProjectDetailsEventArgs e)
        {
            this.projectService.Delete(e.Id);
        }
    }
}
