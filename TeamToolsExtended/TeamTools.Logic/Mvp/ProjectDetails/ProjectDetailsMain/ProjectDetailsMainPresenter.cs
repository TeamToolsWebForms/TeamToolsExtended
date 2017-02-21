using Bytes2you.Validation;
using TeamTools.Logic.Mvp.ProjectDetails.ProjectDetailsMain.Contracts;
using TeamTools.Logic.Services.Contracts;
using WebFormsMvp;

namespace TeamTools.Logic.Mvp.ProjectDetails.ProjectDetailsMain
{
    public class ProjectDetailsMainPresenter : Presenter<IProjectDetailsMainView>
    {
        private readonly IProjectService projectService;
        private readonly IMessageService messageService;

        public ProjectDetailsMainPresenter(
            IProjectDetailsMainView view,
            IProjectService projectService,
            IMessageService messageService)
            : base(view)
        {
            Guard.WhenArgument(projectService, "Project Service").IsNull().Throw();
            Guard.WhenArgument(messageService, "Message Service").IsNull().Throw();

            this.View.DeleteProject += this.View_DeleteProject;
            this.View.LoadProjectMessages += this.View_LoadProjectMessages;

            this.projectService = projectService;
            this.messageService = messageService;
        }

        private void View_LoadProjectMessages(object sender, ProjectDetailsMainEventArgs e)
        {
            this.View.Model.Messages = this.messageService.GetAllProjectMessages(e.ProjectId);
        }

        private void View_DeleteProject(object sender, ProjectDetailsMainEventArgs e)
        {
            this.projectService.Delete(e.ProjectId);
        }
    }
}
