using TeamTools.Logic.DTO;
using TeamTools.Logic.Mvp.Profile.Home.Contracts;
using TeamTools.Logic.Services.Contracts;
using WebFormsMvp;

namespace TeamTools.Logic.Mvp.Profile.Home
{
    public class CreateNotePresenter : Presenter<ICreateNoteView>, ICreateNotePresenter
    {
        private readonly INoteService noteService;

        public CreateNotePresenter(ICreateNoteView view, INoteService noteService)
            : base(view)
        {
            this.View.CreateNewNote += View_CreateNote;
            this.noteService = noteService;
        }

        private void View_CreateNote(object sender, CreateNoteEventArgs e)
        {
            var note = new NoteDTO()
            {
                Title = e.Title,
                Content = e.Content,
                UserId = e.UserId
            };

            this.noteService.Create(note);
        }
    }
}
