using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;

namespace TeamTools.Web
{
    public partial class Profile : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.theFuck.Text = Page.User.Identity.GetUserName();
        }
    }
}