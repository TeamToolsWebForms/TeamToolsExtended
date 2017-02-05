using System.Collections.Generic;
using TeamTools.Logic.DTO;

namespace TeamTools.Logic.Services.Contracts
{
    public interface INoteService
    {
        void Create(NoteDTO note);

        NoteDTO GetById(int id);

        IEnumerable<NoteDTO> GetAllUserNotes(string id);

        void Update(NoteDTO note);
    }
}
