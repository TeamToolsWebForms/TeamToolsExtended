using System.Web.Http;
using TeamTools.Logic.Services.Contracts;

namespace TeamTools.Web.Controllers
{
    public class NoteController : ApiController
    {
        private readonly INoteService noteService;

        public NoteController(INoteService noteService)
        {
            this.noteService = noteService;
        }

        public IHttpActionResult Post(int id)
        {
            var note = this.noteService.GetById(id);
            note.IsImportant = true;
            this.noteService.Update(note);

            return this.Ok("Added as important");
        }

        [HttpPost]
        [Route("api/Note/delete/{id}")]
        public IHttpActionResult DeleteNote(int id)
        {
            var note = this.noteService.GetById(id);
            note.IsDeleted = true;
            this.noteService.Update(note);

            return this.Ok("Note was deleted successfully");
        }
    }
}