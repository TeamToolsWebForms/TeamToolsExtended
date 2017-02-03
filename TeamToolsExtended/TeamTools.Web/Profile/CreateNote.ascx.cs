using System;
using TeamTools.Logic.Mvp.Profile.Home;
using TeamTools.Logic.Mvp.Profile.Home.Contracts;
using WebFormsMvp;
using WebFormsMvp.Web;
using Microsoft.AspNet.Identity;

namespace TeamTools.Web.Profile
{
    [PresenterBinding(typeof(CreateNotePresenter))]
    public partial class CreateNote : MvpUserControl<CreateNoteViewModel>, ICreateNoteView
    {
        public event EventHandler<CreateNoteEventArgs> CreateNewNote;

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void NewNote_Click(object sender, EventArgs e)
        {
            string title = this.title.Text;
            string content = this.content.Text;
            string userId = Page.User.Identity.GetUserId();
            this.CreateNewNote?.Invoke(sender, new CreateNoteEventArgs(title, content, userId));

            this.title.Text = string.Empty;
            this.content.Text = string.Empty;
            // not full validation
            // show the user message for successfull creation of note
        }
    }
}