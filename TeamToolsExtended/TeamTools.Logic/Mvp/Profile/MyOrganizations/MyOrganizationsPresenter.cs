using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamTools.Logic.Mvp.Profile.MyOrganizations.Contracts;
using TeamTools.Logic.Services.Contracts;
using WebFormsMvp;

namespace TeamTools.Logic.Mvp.Profile.MyOrganizations
{
    public class MyOrganizationsPresenter : Presenter<IMyOrganizationsView>
    {
        private readonly IOrganizationService organizationService;

        public MyOrganizationsPresenter(IMyOrganizationsView view, IOrganizationService organizationService)
            : base(view)
        {
            Guard.WhenArgument(view, "View").IsNull().Throw();
            Guard.WhenArgument(organizationService, "Organization Service").IsNull().Throw();

            this.View.LoadMyOrganizations += View_LoadMyOrganizations;

            this.organizationService = organizationService;
        }

        private void View_LoadMyOrganizations(object sender, MyOrganizationsEventArgs e)
        {
            this.View.Model.MyOrganizations = this.organizationService.GetUserOrganizations(e.Id);
        }
    }
}
