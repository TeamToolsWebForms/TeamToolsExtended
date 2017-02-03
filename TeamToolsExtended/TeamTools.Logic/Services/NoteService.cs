using TeamTools.Logic.Data.Contracts;
using TeamTools.Logic.Data.Models;
using TeamTools.Logic.DTO;
using TeamTools.Logic.Services.Contracts;

namespace TeamTools.Logic.Services
{
    public class NoteService : INoteService
    {
        private readonly IRepository<Note> noteRepository;
        private readonly IMapperService mapperService;
        private readonly IUnitOfWork unitOfWork;

        public NoteService(
            IRepository<Note> noteRepository,
            IMapperService mapperService,
            IUnitOfWork unitOfWork)
        {
            this.noteRepository = noteRepository;
            this.mapperService = mapperService;
            this.unitOfWork = unitOfWork;
        }

        public void Create(NoteDTO note)
        {
            var mappedNote = this.mapperService.MapObject<Note>(note);
            this.noteRepository.Add(mappedNote);
            this.unitOfWork.Commit();
        }
    }
}
