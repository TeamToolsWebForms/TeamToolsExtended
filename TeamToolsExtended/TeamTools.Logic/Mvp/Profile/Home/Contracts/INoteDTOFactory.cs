using TeamTools.Logic.DTO;

namespace TeamTools.Logic.Mvp.Profile.Home.Contracts
{
    public interface INoteDTOFactory
    {
        NoteDTO CreateNote(string title, string content, string userId);
    }
}
