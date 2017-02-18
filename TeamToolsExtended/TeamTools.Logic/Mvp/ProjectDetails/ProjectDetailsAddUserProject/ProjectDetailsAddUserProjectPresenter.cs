using Bytes2you.Validation;
using TeamTools.Logic.Mvp.ProjectDetails.ProjectDetailsAddUserProject.Contracts;
using TeamTools.Logic.Services.Contracts;
using WebFormsMvp;

namespace TeamTools.Logic.Mvp.ProjectDetails.ProjectDetailsAddUserProject
{
    public class ProjectDetailsAddUserProjectPresenter : Presenter<IProjectDetailsAddUserProjectView>
    {
        private readonly IProjectService projectService;

        public ProjectDetailsAddUserProjectPresenter(
            IProjectDetailsAddUserProjectView view,
            IProjectService projectService)
            : base(view)
        {
            Guard.WhenArgument(projectService, "Project Service").IsNull().Throw();

            this.View.CheckIsEmailValid += this.View_CheckIsEmailValid;
            this.View.AddUserToProject += this.View_AddUserToProject;
            this.View.LoadOrganizationUsersUnsignedToProject += View_LoadOrganizationUsersUnsignedToProject;

            this.projectService = projectService;
        }

        private void View_LoadOrganizationUsersUnsignedToProject(object sender, ProjectDetailsAddUserProjectEventArgs e)
        {
            this.View.Model.UsersUnsignedToProjectJson = this.projectService.GetUnsignedOrgUsersToProject(e.ProjectId, e.OrganizationId);
        }

        private void View_AddUserToProject(object sender, ProjectDetailsAddUserProjectEventArgs e)
        {
            this.projectService.AddUserToProject(e.ProjectId, e.OrganizationId, e.Email);
        }

        private void View_CheckIsEmailValid(object sender, ProjectDetailsAddUserProjectEventArgs e)
        {
            this.View.Model.IsEmailValid = this.projectService.IsUserValid(e.OrganizationId, e.Email);
        }
    }
}
