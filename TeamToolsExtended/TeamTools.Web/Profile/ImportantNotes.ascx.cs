using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TeamTools.Logic.Mvp.Profile.Home;
using WebFormsMvp.Web;
using Microsoft.AspNet.Identity;
using WebFormsMvp;
using TeamTools.Logic.Mvp.Profile.Home.Contracts;

namespace TeamTools.Web.Profile
{
    [PresenterBinding(typeof(ProfileHomeImortantNotesPresenter))]
    public partial class ImportantNotes : MvpUserControl<MyNotesViewModel>, IImportantNoteView
    {
        public event EventHandler<MyNotesEventArgs> LoadImportantUserNotes;

        protected void Page_Load(object sender, EventArgs e)
        {
            string userId = Page.User.Identity.GetUserId();
            this.LoadImportantUserNotes?.Invoke(sender, new MyNotesEventArgs(userId));

            this.ImportantNotesList.DataSource = this.Model.UserNotes.ToList();
            this.ImportantNotesList.DataBind();
        }

        protected void ImportantNotesList_Sorting(object sender, ListViewSortEventArgs e)
        {
            if (e.SortExpression == "Id")
            {
                this.ImportantNotesList.DataSource = this.Model.UserNotes.OrderByDescending(x => x.Id).ToList();
            }
            else
            {
                this.ImportantNotesList.DataSource = this.Model.UserNotes.OrderBy(x => x.Title).ToList();
            }

            this.ImportantNotesList.DataBind();
        }
    }
}