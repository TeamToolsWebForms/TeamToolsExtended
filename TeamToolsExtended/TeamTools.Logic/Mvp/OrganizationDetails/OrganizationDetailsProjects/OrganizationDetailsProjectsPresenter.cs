using Bytes2you.Validation;
using TeamTools.Logic.Mvp.OrganizationDetails.OrganizationDetailsProjects.Contracts;
using TeamTools.Logic.Services.Contracts;
using WebFormsMvp;

namespace TeamTools.Logic.Mvp.OrganizationDetails.OrganizationDetailsProjects
{
    public class OrganizationDetailsProjectsPresenter : Presenter<IOrganizationDetailsProjectsView>
    {
        private readonly IOrganizationService organizationService;
        private readonly IProjectService projectService;

        public OrganizationDetailsProjectsPresenter(
            IOrganizationDetailsProjectsView view,
            IOrganizationService organizationService,
            IProjectService projectService)
            : base(view)
        {
            Guard.WhenArgument(organizationService, "Organization Service").IsNull().Throw();
            Guard.WhenArgument(projectService, "Project Service").IsNull().Throw();

            this.View.LoadOrganization += this.View_LoadOrganization;
            this.View.UpdateOrganizationProject += this.View_UpdateOrganizationProject;
            this.View.DeleteOrganizationProject += this.View_DeleteOrganizationProject;
            this.View.CreateProject += this.View_CreateProject;

            this.organizationService = organizationService;
            this.projectService = projectService;
        }

        private void View_CreateProject(object sender, OrganizationDetailsProjectsEventArgs e)
        {
            this.projectService.CreateOrganizationProject(e.Id, e.ProjectTitle, e.Description, e.Creator);
            this.View.Model.Organization = this.organizationService.GetById(e.Id);
        }

        private void View_DeleteOrganizationProject(object sender, OrganizationDetailsProjectsEventArgs e)
        {
            this.projectService.Delete(e.Id);
            this.View.Model.Organization = this.organizationService.GetById(e.OrganizationId);
        }

        private void View_UpdateOrganizationProject(object sender, OrganizationDetailsProjectsEventArgs e)
        {
            this.projectService.Update(e.Id, e.ProjectTitle);
            this.View.Model.Organization = this.organizationService.GetById(e.OrganizationId);
        }

        private void View_LoadOrganization(object sender, OrganizationDetailsProjectsEventArgs e)
        {
            this.View.Model.Organization = this.organizationService.GetById(e.Id);
        }
    }
}
