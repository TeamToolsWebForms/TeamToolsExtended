using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using TeamTools.Logic.Mvp.Profile.Home;
using TeamTools.Logic.Mvp.Profile.Home.Contracts;
using WebFormsMvp;
using WebFormsMvp.Web;
using Microsoft.AspNet.Identity;

namespace TeamTools.Web.Profile
{
    [PresenterBinding(typeof(ProfileHomeMyNotesPresenter))]
    public partial class MyNotes : MvpUserControl<MyNotesViewModel>, IMyNotesView
    {
        public event EventHandler<MyNotesEventArgs> LoadUserNotes;

        protected void Page_Load(object sender, EventArgs e)
        {
            string userId = Page.User.Identity.GetUserId();
            this.LoadUserNotes?.Invoke(sender, new MyNotesEventArgs(userId));

            this.MyNotesList.DataSource = this.Model.UserNotes.ToList();
            this.MyNotesList.DataBind();
        }

        protected void MyNotesList_Sorting(object sender, ListViewSortEventArgs e)
        {
            if (e.SortExpression == "Id")
            {
                this.MyNotesList.DataSource = this.Model.UserNotes.OrderBy(x => x.Id).ToList();
            }
            else
            {
                this.MyNotesList.DataSource = this.Model.UserNotes.OrderBy(x => x.Title).ToList();
            }
            
            this.MyNotesList.DataBind();
        }
    }
}