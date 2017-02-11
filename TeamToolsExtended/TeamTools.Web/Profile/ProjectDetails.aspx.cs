using System;
using System.Web.UI;
using TeamTools.Logic.Data;
using TeamTools.Logic.Data.Models;
using TeamTools.Logic.DTO;

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