using System;
using System.Web.UI;

namespace TeamTools.Web
{
    public partial class OrganizationDetails : Page
    {
        private const string RedirectUrl = "~/Profile/MyOrganizations";

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
    }
}