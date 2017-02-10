using System;
using System.Web.UI;

namespace TeamTools.Web.Profile
{
    public partial class ProjectDetails : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Request.Params["id"] == null)
                {
                    Response.Redirect("~/Profile/MyProjects.aspx");
                }
            }
        }
    }
}