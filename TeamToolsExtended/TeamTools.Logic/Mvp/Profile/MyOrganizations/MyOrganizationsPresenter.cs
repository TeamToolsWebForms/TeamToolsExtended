using Bytes2you.Validation;
using TeamTools.Logic.Mvp.Profile.MyOrganizations.Contracts;
using TeamTools.Logic.Services.Contracts;
using TeamTools.Logic.Services.Helpers.Contracts;
using WebFormsMvp;

namespace TeamTools.Logic.Mvp.Profile.MyOrganizations
{
    public class MyOrganizationsPresenter : Presenter<IMyOrganizationsView>
    {
        private readonly IOrganizationService organizationService;
        private readonly IOrganizationFactory organizationFactory;
        private readonly IOrganizationLogoFactory organizationLogoFactory;
        private readonly IImageHelper imageHelper;

        public MyOrganizationsPresenter(
            IMyOrganizationsView view,
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

            this.organizationService = organizationService;
            this.organizationFactory = organizationFactory;
            this.organizationLogoFactory = organizationLogoFactory;
            this.imageHelper = imageHelper;
        }

        private void View_SaveOrganization(object sender, OrganizationsEventArgs e)
        {
            var image = this.imageHelper.GetImage(e.DefaultLogoPath);
            var imageContent = this.imageHelper.ImageToByteArray(image);
            var organizationLogoUrl = this.imageHelper.ByteArrayToImageUrl(imageContent);
            var organizationLogo = this.organizationLogoFactory.CreateOrganizationLogo(imageContent);
            
            var organization = this.organizationFactory.CreateOrganization(e.Name, e.Description, organizationLogo, e.Username, organizationLogoUrl);
            this.organizationService.Create(organization, e.Id);
        }

        private void View_LoadMyOrganizations(object sender, OrganizationsEventArgs e)
        {
            this.View.Model.MyOrganizations = this.organizationService.GetUserOrganizations(e.Id);
        }
    }
}
