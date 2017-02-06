using System;
using TeamTools.Logic.Mvp.Profile.Home;
using TeamTools.Logic.Mvp.Profile.Home.Contracts;
using WebFormsMvp;
using WebFormsMvp.Web;
using Microsoft.AspNet.Identity;
using System.Web.UI;

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
            
            if (title.Length < 3 || title.Length > 100)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "titleValidation();", true);
                return;
            }

            if (content.Length < 3 || content.Length > 100)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "contentValidation();", true);
                return;
            }

            string userId = Page.User.Identity.GetUserId();
            this.CreateNewNote?.Invoke(sender, new CreateNoteEventArgs(title, content, userId));

            this.title.Text = string.Empty;
            this.content.Text = string.Empty;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "noteSuccess();", true);
        }
    }
}