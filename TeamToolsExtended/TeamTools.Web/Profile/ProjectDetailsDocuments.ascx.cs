using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TeamTools.Logic.Data;

namespace TeamTools.Web.Profile
{
    public partial class ProjectDetailsDocuments : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DownloadFile_Click(object sender, EventArgs e)
        {
            var context = TeamToolsDbContext.Create();
            var image = context.UserLogos.FirstOrDefault();

            Response.ContentType = ".jpg";
            Response.AddHeader("Content-Disposition", "attachment;filename=Userlogo");
            Response.BinaryWrite(image.Image);
            Response.End();
        }
    }
}