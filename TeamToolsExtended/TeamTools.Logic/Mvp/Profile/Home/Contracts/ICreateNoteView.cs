using System;
using WebFormsMvp;

namespace TeamTools.Logic.Mvp.Profile.Home.Contracts
{
    public interface ICreateNoteView : IView<CreateNoteViewModel>
    {
        event EventHandler<CreateNoteEventArgs> CreateNewNote;
    }
}
