using TeamTools.Logic.Mvp.Profile.Home.Contracts;
using TeamTools.Logic.Services.Contracts;
using WebFormsMvp;

namespace TeamTools.Logic.Mvp.Profile.Home
{
    public class ProfileHomeMyNotesPresenter : Presenter<IMyNotesView>
    {
        private readonly INoteService noteService;

        public ProfileHomeMyNotesPresenter(IMyNotesView view, INoteService noteService)
            : base(view)
        {
            this.noteService = noteService;

            this.View.LoadUserNotes += View_LoadUserNotes;
        }

        private void View_LoadUserNotes(object sender, MyNotesEventArgs e)
        {
            this.View.Model.UserNotes = this.noteService.GetAllUserNotes(e.Id);
        }
    }
}
