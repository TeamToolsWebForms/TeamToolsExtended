using Bytes2you.Validation;
using TeamTools.Logic.Mvp.Profile.Home.Contracts;
using TeamTools.Logic.Services.Contracts;
using WebFormsMvp;

namespace TeamTools.Logic.Mvp.Profile.Home
{
    public class ProfileHomeImortantNotesPresenter : Presenter<IImportantNoteView>
    {
        private readonly INoteService noteService;

        public ProfileHomeImortantNotesPresenter(IImportantNoteView view, INoteService noteService)
            : base(view)
        {
            Guard.WhenArgument(noteService, "Note Service").IsNull().Throw();

            this.View.LoadImportantUserNotes += this.View_LoadImportantUserNotes;

            this.noteService = noteService;
        }

        private void View_LoadImportantUserNotes(object sender, MyNotesEventArgs e)
        {
            this.View.Model.UserNotes = this.noteService.GetAllImportantUserNotes(e.Id);
        }
    }
}
