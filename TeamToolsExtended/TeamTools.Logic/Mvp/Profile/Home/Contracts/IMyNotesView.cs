using System;
using WebFormsMvp;

namespace TeamTools.Logic.Mvp.Profile.Home.Contracts
{
    public interface IMyNotesView : IView<MyNotesViewModel>
    {
        event EventHandler<MyNotesEventArgs> LoadUserNotes;
    }
}
