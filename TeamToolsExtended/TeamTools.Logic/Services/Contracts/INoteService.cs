using TeamTools.Logic.DTO;

namespace TeamTools.Logic.Services.Contracts
{
    public interface INoteService
    {
        void Create(NoteDTO note);
    }
}
