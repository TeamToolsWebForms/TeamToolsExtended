using System;
using TeamTools.Logic.Mvp.OrganizationDetails.OrganizationDetailsHome;
using TeamTools.Logic.Mvp.OrganizationDetails.OrganizationDetailsHome.Contracts;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace TeamTools.Web
{
    [PresenterBinding(typeof(OrganizationDetailsHomePresenter))]
    public partial class OrganizationDetailsHome : MvpUserControl<OrganizationDetailsHomeViewModel>, IOrganizationDetailsHomeView
    {
        private const string RedirectUrl = "~/profile/myorganizations";

        public event EventHandler<OrganizationDetailsHomeEventArgs> LoadOrganization;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Request.Params["id"] == null)
            {
                this.Response.Redirect(RedirectUrl);
            }
            else
            {
                try
                {
                    int paramId = int.Parse(this.Request.Params["id"]);
                    this.LoadOrganization?.Invoke(sender, new OrganizationDetailsHomeEventArgs(paramId));
                    this.OrganizationMembersRepeater.DataSource = this.Model.Organization.Users;
                    this.OrganizationMembersRepeater.DataBind();
                }
                catch (FormatException)
                {
                    this.Response.Redirect(RedirectUrl);
                }
            }
        }
    }
}