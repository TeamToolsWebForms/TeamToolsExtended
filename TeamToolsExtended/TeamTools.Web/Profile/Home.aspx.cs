using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsMvp.Web;

namespace TeamTools.Web.Profile
{
    public partial class Home : Page
    {
        //private const string RelativePath = "~/Profile/";
        //private const string UserControlSuffix = ".ascx";

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void MyNotes_Click(object sender, EventArgs e)
        {
            this.PersonalInfoControl.Visible = false;
            this.CreateNoteControl.Visible = false;
            this.MyNotesControl.Visible = true;
            //LinkButton button = sender as LinkButton;
            //this.LoadSpecificUserControl(RelativePath, button.ID, UserControlSuffix);
        }

        protected void CreateNote_Click(object sender, EventArgs e)
        {
            this.MyNotesControl.Visible = false;
            this.PersonalInfoControl.Visible = false;
            this.CreateNoteControl.Visible = true;
        }

        //private void LoadSpecificUserControl(string relativePath, string userControlName, string userControlSuffix)
        //{
        //    string fullPath = relativePath + userControlName + userControlSuffix;
        //    this.MyControls.Controls.Clear();
        //    UserControl userControl = (UserControl)this.LoadControl(fullPath);
        //    this.MyControls.Controls.Add(userControl);
        //}
    }
}