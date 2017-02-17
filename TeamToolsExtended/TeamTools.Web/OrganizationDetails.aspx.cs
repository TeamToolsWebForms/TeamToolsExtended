using System;
using System.Web.UI;

namespace TeamTools.Web
{
    public partial class OrganizationDetails : Page
    {
        private const string RedirectUrl = "~/profile/myorganizations";

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
                }
                catch (FormatException)
                {
                    this.Response.Redirect(RedirectUrl);
                }
            }
        }

        protected void OrganizationProfile_Click(object sender, EventArgs e)
        {
            this.OrganizationProjectsControl.Visible = false;
            this.OrganizationAddUserControl.Visible = false;
            this.OrganizationHomeControl.Visible = true;
        }

        protected void LeaveOrganizationBtn_ServerClick(object sender, EventArgs e)
        {

        }

        protected void OrganizationAddUser_Click(object sender, EventArgs e)
        {
            this.OrganizationProjectsControl.Visible = false;
            this.OrganizationAddUserControl.Visible = true;
            this.OrganizationHomeControl.Visible = false;
        }

        protected void OrganizationProjects_Click(object sender, EventArgs e)
        {
            this.OrganizationProjectsControl.Visible = true;
            this.OrganizationAddUserControl.Visible = false;
            this.OrganizationHomeControl.Visible = false;
        }
    }
}