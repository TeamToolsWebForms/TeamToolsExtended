using TeamTools.Logic.Mvp.Profile.Home.Contracts;
using TeamTools.Logic.Services.Contracts;
using WebFormsMvp;

namespace TeamTools.Logic.Mvp.Profile.Home
{
    public class ProfileHomeTrashNotesPresenter : Presenter<ITrashNotesView>
    {
        private readonly INoteService noteService;

        public ProfileHomeTrashNotesPresenter(ITrashNotesView view, INoteService noteService)
            : base(view)
        {
            this.View.LoadDeletedNotes += View_LoadDeletedNotes;

            this.noteService = noteService;
        }

        private void View_LoadDeletedNotes(object sender, MyNotesEventArgs e)
        {
            this.View.Model.UserNotes = this.noteService.GetAllDeleteUserNotes(e.Id);
        }
    }
}
