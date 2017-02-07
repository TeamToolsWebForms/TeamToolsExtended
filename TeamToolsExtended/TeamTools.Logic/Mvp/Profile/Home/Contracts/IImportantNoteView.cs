using System;
using WebFormsMvp;

namespace TeamTools.Logic.Mvp.Profile.Home.Contracts
{
    public interface IImportantNoteView : IView<MyNotesViewModel>
    {
        event EventHandler<MyNotesEventArgs> LoadImportantUserNotes;
    }
}
