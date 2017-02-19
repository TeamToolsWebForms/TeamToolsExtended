using System;
using System.Web;
using System.Web.UI;
using TeamTools.Authentication;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace TeamTools.Web.Profile
{
    public partial class Home : Page
    {
        protected void MyProfile_Click(object sender, EventArgs e)
        {
            this.TrashNotesControl.Visible = false;
            this.ImportantNotesControl.Visible = false;
            this.CreateNoteControl.Visible = false;
            this.MyNotesControl.Visible = false;
            this.PersonalInfoControl.Visible = true;
        }

        protected void MyNotes_Click(object sender, EventArgs e)
        {
            this.TrashNotesControl.Visible = false;
            this.ImportantNotesControl.Visible = false;
            this.PersonalInfoControl.Visible = false;
            this.CreateNoteControl.Visible = false;
            this.MyNotesControl.Visible = true;
        }

        protected void CreateNote_Click(object sender, EventArgs e)
        {
            this.TrashNotesControl.Visible = false;
            this.ImportantNotesControl.Visible = false;
            this.MyNotesControl.Visible = false;
            this.PersonalInfoControl.Visible = false;
            this.CreateNoteControl.Visible = true;
        }

        protected void ImportantNotes_Click(object sender, EventArgs e)
        {
            this.TrashNotesControl.Visible = false;
            this.MyNotesControl.Visible = false;
            this.PersonalInfoControl.Visible = false;
            this.CreateNoteControl.Visible = false;
            this.ImportantNotesControl.Visible = true;
        }

        protected void TrashNotes_Click(object sender, EventArgs e)
        {
            this.MyNotesControl.Visible = false;
            this.PersonalInfoControl.Visible = false;
            this.CreateNoteControl.Visible = false;
            this.ImportantNotesControl.Visible = false;
            this.TrashNotesControl.Visible = true;
        }
    }
}