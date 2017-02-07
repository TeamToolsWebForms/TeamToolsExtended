using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using WebFormsMvp.Web;
using TeamTools.Logic.Mvp.Profile.Home;
using TeamTools.Logic.Mvp.Profile.Home.Contracts;
using WebFormsMvp;

namespace TeamTools.Web.Profile
{
    [PresenterBinding(typeof(ProfileHomeTrashNotesPresenter))]
    public partial class TrashNotes : MvpUserControl<MyNotesViewModel>, ITrashNotesView
    {
        public event EventHandler<MyNotesEventArgs> LoadDeletedNotes;

        protected void Page_Load(object sender, EventArgs e)
        {
            string userId = Page.User.Identity.GetUserId();
            this.LoadDeletedNotes?.Invoke(sender, new MyNotesEventArgs(userId));

            this.TrashNotesList.DataSource = this.Model.UserNotes.ToList();
            this.TrashNotesList.DataBind();
        }

        protected void TrashNotesList_Sorting(object sender, ListViewSortEventArgs e)
        {
            if (e.SortExpression == "Id")
            {
                this.TrashNotesList.DataSource = this.Model.UserNotes.OrderByDescending(x => x.Id).ToList();
            }
            else
            {
                this.TrashNotesList.DataSource = this.Model.UserNotes.OrderBy(x => x.Title).ToList();
            }

            this.TrashNotesList.DataBind();
        }
    }
}