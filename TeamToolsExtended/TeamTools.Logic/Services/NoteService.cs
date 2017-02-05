using System;
using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<NoteDTO> GetAllUserNotes(string id)
        {
            return this.noteRepository
                .All(u => u.UserId == id)
                .Select(n => this.mapperService.MapObject<NoteDTO>(n));
        }

        public NoteDTO GetById(int id)
        {
            var note = this.noteRepository.GetById(id);
            return this.mapperService.MapObject<NoteDTO>(note);
        }

        public void Update(NoteDTO note)
        {
            var mappedNote = this.mapperService.MapObject<Note>(note);
            this.noteRepository.Update(mappedNote);
            this.unitOfWork.Commit();
        }
    }
}
