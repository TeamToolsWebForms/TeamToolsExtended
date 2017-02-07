﻿using System;
using System.Web.UI;

namespace TeamTools.Web.Profile
{
    public partial class Home : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void MyProfile_Click(object sender, EventArgs e)
        {
            this.ImportantNotesControl.Visible = false;
            this.MyProjectsControl.Visible = false;
            this.CreateNoteControl.Visible = false;
            this.MyNotesControl.Visible = false;
            this.PersonalInfoControl.Visible = true;
        }

        protected void MyNotes_Click(object sender, EventArgs e)
        {
            this.ImportantNotesControl.Visible = false;
            this.MyProjectsControl.Visible = false;
            this.PersonalInfoControl.Visible = false;
            this.CreateNoteControl.Visible = false;
            this.MyNotesControl.Visible = true;
        }

        protected void CreateNote_Click(object sender, EventArgs e)
        {
            this.ImportantNotesControl.Visible = false;
            this.MyProjectsControl.Visible = false;
            this.MyNotesControl.Visible = false;
            this.PersonalInfoControl.Visible = false;
            this.CreateNoteControl.Visible = true;
        }

        protected void MyProjects_Click(object sender, EventArgs e)
        {
            this.ImportantNotesControl.Visible = false;
            this.MyNotesControl.Visible = false;
            this.PersonalInfoControl.Visible = false;
            this.CreateNoteControl.Visible = false;
            this.MyProjectsControl.Visible = true;
        }

        protected void ImportantNotes_Click(object sender, EventArgs e)
        {
            this.MyNotesControl.Visible = false;
            this.PersonalInfoControl.Visible = false;
            this.CreateNoteControl.Visible = false;
            this.MyProjectsControl.Visible = false;
            this.ImportantNotesControl.Visible = true;
        }
    }
}