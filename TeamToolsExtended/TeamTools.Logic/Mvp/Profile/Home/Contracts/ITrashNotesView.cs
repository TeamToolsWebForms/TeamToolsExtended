using System;
using WebFormsMvp;

namespace TeamTools.Logic.Mvp.Profile.Home.Contracts
{
    public interface ITrashNotesView : IView<MyNotesViewModel>
    {
        event EventHandler<MyNotesEventArgs> LoadDeletedNotes;
    }
}
