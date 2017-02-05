using System.Collections.Generic;
using TeamTools.Logic.DTO;

namespace TeamTools.Logic.Mvp.Profile.Home
{
    public class MyNotesViewModel
    {
        public IEnumerable<NoteDTO> UserNotes { get; set; }
    }
}
