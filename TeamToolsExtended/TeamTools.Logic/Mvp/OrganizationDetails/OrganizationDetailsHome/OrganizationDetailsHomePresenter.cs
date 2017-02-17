using Bytes2you.Validation;
using TeamTools.Logic.Mvp.OrganizationDetails.OrganizationDetailsHome.Contracts;
using TeamTools.Logic.Services.Contracts;
using WebFormsMvp;

namespace TeamTools.Logic.Mvp.OrganizationDetails.OrganizationDetailsHome
{
    public class OrganizationDetailsHomePresenter : Presenter<IOrganizationDetailsHomeView>
    {
        private readonly IOrganizationService organizationService;

        public OrganizationDetailsHomePresenter(IOrganizationDetailsHomeView view, IOrganizationService organizationService)
            : base(view)
        {
            Guard.WhenArgument(organizationService, "Organization Service").IsNull().Throw();

            this.View.LoadOrganization += this.View_LoadOrganization;

            this.organizationService = organizationService;
        }

        private void View_LoadOrganization(object sender, OrganizationDetailsHomeEventArgs e)
        {
            this.View.Model.Organization = this.organizationService.GetById(e.Id);
        }
    }
}
