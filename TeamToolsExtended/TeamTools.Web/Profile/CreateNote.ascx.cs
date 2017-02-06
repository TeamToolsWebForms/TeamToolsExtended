using System;
using TeamTools.Logic.Mvp.Profile.Home;
using TeamTools.Logic.Mvp.Profile.Home.Contracts;
using WebFormsMvp;
using WebFormsMvp.Web;
using Microsoft.AspNet.Identity;
using System.Web.UI;
using TeamTools.Web.Helpers;

namespace TeamTools.Web.Profile
{
    [PresenterBinding(typeof(CreateNotePresenter))]
    public partial class CreateNote : MvpUserControl<CreateNoteViewModel>, ICreateNoteView
    {
        private const int MinLength = 3;
        private const int MaxLength = 100;

        public event EventHandler<CreateNoteEventArgs> CreateNewNote;

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void NewNote_Click(object sender, EventArgs e)
        {
            string title = this.title.Text;
            string content = this.content.Text;
            
            if (!Validator.ValidateRange(title, MinLength, MaxLength))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "titleValidation();", true);
                return;
            }

            if (!Validator.ValidateRange(content, MinLength, MaxLength))
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