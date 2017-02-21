using Bytes2you.Validation;
using TeamTools.Logic.Mvp.Organizations.Contracts;
using TeamTools.Logic.Mvp.Profile.MyOrganizations;
using TeamTools.Logic.Mvp.Profile.MyOrganizations.Contracts;
using TeamTools.Logic.Services.Contracts;
using TeamTools.Logic.Services.Helpers.Contracts;
using WebFormsMvp;

namespace TeamTools.Logic.Mvp.Organizations
{
    public class OrganizationsPresenter : Presenter<IOrganizationsView>
    {
        private readonly IOrganizationService organizationService;
        private readonly IOrganizationFactory organizationFactory;
        private readonly IOrganizationLogoFactory organizationLogoFactory;
        private readonly IImageHelper imageHelper;

        public OrganizationsPresenter(
            IOrganizationsView view,
            IOrganizationService organizationService,
            IOrganizationFactory organizationFactory,
            IOrganizationLogoFactory organizationLogoFactory,
            IImageHelper imageHelper)
            : base(view)
        {
            Guard.WhenArgument(organizationService, "Organization Service").IsNull().Throw();
            Guard.WhenArgument(organizationFactory, "Organization Factory").IsNull().Throw();
            Guard.WhenArgument(organizationLogoFactory, "OrganizationLogo Factory").IsNull().Throw();
            Guard.WhenArgument(imageHelper, "Image Helper").IsNull().Throw();

            this.View.LoadMyOrganizations += this.View_LoadMyOrganizations;
            this.View.SaveOrganization += this.View_SaveOrganization;
            this.View.CanJoinOrganization += this.View_CanJoinOrganization;
            this.View.JoinOrganization += this.View_JoinOrganization;

            this.organizationService = organizationService;
            this.organizationFactory = organizationFactory;
            this.organizationLogoFactory = organizationLogoFactory;
            this.imageHelper = imageHelper;
        }

        private void View_JoinOrganization(object sender, OrganizationsEventArgs e)
        {
            this.organizationService.JoinOrganization(e.OrganizationId, e.Username);
        }

        private void View_CanJoinOrganization(object sender, OrganizationsEventArgs e)
        {
            this.View.Model.CanJoinOrganization = this.organizationService.CanUserJoinOrganization(e.OrganizationId, e.Username);
        }

        private void View_SaveOrganization(object sender, OrganizationsEventArgs e)
        {
            var image = this.imageHelper.GetImage(e.DefaultLogoPath);
            var imageContent = this.imageHelper.ImageToByteArray(image);
            var organizationLogoUrl = this.imageHelper.ByteArrayToImageUrl(imageContent);
            var organizationLogo = this.organizationLogoFactory.CreateOrganizationLogo(imageContent);

            var organization = this.organizationFactory.CreateOrganization(e.Name, e.Description, organizationLogo, e.Username, organizationLogoUrl);
            this.organizationService.Create(organization, e.Id);
            this.View.Model.Organizations = this.organizationService.GetOrganizations();
        }

        private void View_LoadMyOrganizations(object sender, OrganizationsEventArgs e)
        {
            this.View.Model.Organizations = this.organizationService.GetOrganizations();
        }
    }
}
